using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Entities;
using VismaHomework.Services.JsonHandler;

namespace VismaHomework.Services.FilterCommands.cs
{
   public class FilterCommands : IFilterCommands
    {
        private readonly IJsonHandler _jsonHandler;
        public FilterCommands(IJsonHandler jsonHandler) {
            _jsonHandler = jsonHandler;
        }
        public void PrintFilteredBooks(string filterBy) {
            var books= _jsonHandler.ReturnAllBookDataFromJson();
            var table = new ConsoleTable(filterBy);
            System.Reflection.PropertyInfo prop = typeof(Book).GetProperty(filterBy);
            var orderedBooks=books.OrderBy(b=>prop.GetValue(b,null));
            foreach (var book in orderedBooks) {
                table.AddRow(book.GetType().GetProperty(filterBy).GetValue(book,null));
            }
            table.Write();
        }
        public void PrintAllBooks() {
            var Books = _jsonHandler.ReturnAllBookDataFromJson();
            var table = new ConsoleTable("Name", "Author", "Category", "Language", "Publication Date", "ISBN");
       
            foreach (var book in Books)
            {
                table.AddRow(
                    book.Name, book.Author, book.Category, book.Language, book.PublicationDate, book.ISBN
                    );
            }
            table.Write();
        }
        public void PrintTakenBooks() {
            var Books = _jsonHandler.ReturnAllBookDataFromJson();
            var table = new ConsoleTable("Name", "Author", "Category", "Language", "Publication Date", "ISBN");
            foreach (var book in Books)
            {
                if (book.reservedUntill != null)
                {
                    table.AddRow(
                        book.Name, book.Author, book.Category, book.Language, book.PublicationDate, book.ISBN
                        );
                }
            }
            table.Write();
        }
        public void PrintAvailableBooks() {
            var Books = _jsonHandler.ReturnAllBookDataFromJson();
            var table = new ConsoleTable("Name", "Author", "Category", "Language", "Publication Date", "ISBN");
            foreach (var book in Books)
            {
                if (book.reservedUntill == null)
                {
                    table.AddRow(
                        book.Name, book.Author, book.Category, book.Language, book.PublicationDate, book.ISBN
                        );
                }
            }
            table.Write();
        }
    }
}
