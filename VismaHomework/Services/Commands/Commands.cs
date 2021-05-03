using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Entities;
using VismaHomework.Models;
using VismaHomework.Services.ConsoleWriter;
using VismaHomework.Services.JsonHandler;

namespace VismaHomework.Services.Commands
{
   public class Commands : ICommands
    {
        private readonly IJsonHandler _jsonHandler;
        private readonly IConsoleWriter _consoleWriter;
        public Commands(IJsonHandler jsonHandler,IConsoleWriter consoleWriter) {
            _jsonHandler = jsonHandler;
            _consoleWriter = consoleWriter;
        }
        public void AddBookToJson() {
            try
            {
                var BookList = _jsonHandler.ReturnAllBookDataFromJson();
                var newBook = _consoleWriter.GetBookData();
                if (BookList.Any(b => b.Name.ToLower() == newBook.Name.ToLower()))
                {
                    throw new Exception("Book already exsists");
                }
                BookList.Add(newBook);
                _jsonHandler.UpdateBookJson(BookList);
            }
            catch(Exception ex) {
                _consoleWriter.Write(ex.Message);
            }
        }
        public void RemoveBookFromJson() {
            try
            {
                _consoleWriter.Write("Enter the name of the book you want to remove");
                var deleteBookName = _consoleWriter.Read();
                var allBooks = _jsonHandler.ReturnAllBookDataFromJson();
                var book = allBooks.Find(a => a.Name.ToLower() == deleteBookName.ToLower());
                if (book == null)
                {
                    throw new Exception("This book doesn't exsist in the library");
                }
                var allCustomers = _jsonHandler.ReturnAllCustomerDataFromJson();
                if (book.PublicationDate != null)
                {
                    foreach (var customer in allCustomers) {
                     customer.TakenBooks=customer.TakenBooks.Where(b => b.Name.ToLower() != book.Name.ToLower()).ToList();
                    }
                    _jsonHandler.UpdateCustomerJson(allCustomers);
                }
                allBooks.Remove(book);
                _jsonHandler.UpdateBookJson(allBooks);
                _consoleWriter.Write($"Book {deleteBookName} removed");
            }
            catch (Exception ex)
            {
                _consoleWriter.Write(ex.Message);
            }
        }
        public void TakeBook() {
            try
            {
                _consoleWriter.Write("Enter The name of the book you want to take");
              var bookName=_consoleWriter.Read();
                var allBooks = _jsonHandler.ReturnAllBookDataFromJson();
                if (!allBooks.Any(b => b.Name.ToLower() == bookName.ToLower())) {
                    throw new Exception("Book doensn't exsist");
                }
                if (allBooks.FirstOrDefault(b => b.Name.ToLower() == bookName.ToLower()).reservedUntill != null) {
                    throw new Exception("Book is already reserved");
                }
                _consoleWriter.Write("Enter the name of who is taking the book");
                var customerName = _consoleWriter.Read();
                var allCustomers = _jsonHandler.ReturnAllCustomerDataFromJson();
                bool hasCustomer = allCustomers.Any(c => c.Name.ToLower() == customerName.ToLower());
                if (hasCustomer) {
                    var bookCount = allCustomers.FirstOrDefault(c => c.Name.ToLower() == customerName.ToLower()).TakenBooks.Count();
                    if (bookCount>=3){
                        throw new Exception("Can't reserve more than 3 books");
                    }
                }
                _consoleWriter.Write("Untill what date would you like to reserve the book?(eg.10/22/2021)");
                var reserveUntillDate = DateTime.Parse(_consoleWriter.Read());
                var nextTwoMonths = DateTime.Today.AddMonths(2);
                if (reserveUntillDate > nextTwoMonths)
                {
                    throw new Exception("You canno't reserve for longer than 2 months");
                }
                else if (reserveUntillDate < DateTime.Today) {
                    throw new Exception("Cannot go back in time");
                }
             
          
                var customer = new Customer();
                if (!hasCustomer) {
                    customer.Name = customerName;
                    customer.TakenBooks = new List<Book>();
                    allCustomers.Add(customer);
                }
         
                foreach (var book in allBooks) {
                    if (book.Name.ToLower() == bookName.ToLower()) {
                        book.reservedUntill = reserveUntillDate;
                        foreach (var customerModel in allCustomers) {
                            if (customerModel.Name.ToLower() == customerName.ToLower()) {
                                customerModel.TakenBooks.Add(book);
                                break;
                            }
                        }
                        break;
                    }
                }
                _jsonHandler.UpdateBookJson(allBooks);
                _jsonHandler.UpdateCustomerJson(allCustomers);
                _consoleWriter.Write("Book successfully reserved");
            }
            catch (Exception ex) {
               _consoleWriter.Write(ex.Message);
            }
        }
        public void returnBook() {
            try
            {
                _consoleWriter.Write("Who is returning the book?");
                var customerName = _consoleWriter.Read();
                var allCustomers = _jsonHandler.ReturnAllCustomerDataFromJson();
                if (!allCustomers.Any(b => b.Name.ToLower() == customerName.ToLower()))
                {
                    throw new Exception("Customer has no books reserved");
                }
                _consoleWriter.Write("You can return: ");
                var availableBooks = new List<Book>();
                foreach (var customer in allCustomers) {
                    if (customer.Name.ToLower() == customerName.ToLower()) {
                        foreach (var book in customer.TakenBooks) {
                            _consoleWriter.Write(book.Name);
                            availableBooks.Add(book);
                        }
                    }
                }
                if (availableBooks.Count() == 0) {
                    throw new Exception("No books to return");
                }
                _consoleWriter.Write("Enter the name of the book you want to return");

                var returningBook = _consoleWriter.Read();
                if (!availableBooks.Any(b=>b.Name.ToLower()==returningBook.ToLower()))
                {
                    throw new Exception("Customer didn't reserve this book");
                }
                var allBooks = _jsonHandler.ReturnAllBookDataFromJson();
                foreach (var book in allBooks) {
                    if (book.Name.ToLower() == returningBook.ToLower()) {
                        foreach (var customer in allCustomers)
                        {
                            if (customer.Name.ToLower() == customerName.ToLower())
                            {
                                customer.TakenBooks = customer.TakenBooks.Where(a => a.Name != book.Name).ToList();
                                break;
                            }
                        }
                        if (book.reservedUntill < DateTime.Today) {
                            _consoleWriter.Write("A funny message");
                        }
                        book.reservedUntill = null;
                        break;
                    }
                }
                _jsonHandler.UpdateBookJson(allBooks);
                _jsonHandler.UpdateCustomerJson(allCustomers);
                _consoleWriter.Write("Book returned");
            }
            catch (Exception ex){
                _consoleWriter.Write(ex.Message); 
            }
        }
        public void EndProgram() {
            System.Environment.Exit(0);
        }

    }
}
