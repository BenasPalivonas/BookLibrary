using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Entities;
using VismaHomework.Models;
using VismaHomework.Services.FilterCommands.cs;
using VismaHomework.Services.JsonHandler;
namespace VismaHomework.tests
{
    [TestClass]
  public class FilterCommandsTest
    {
        IJsonHandler _jsonHandler;
        [TestInitialize]
        public void Setup() {
            var Books = new List<Book> {
            new Book{
            Name="Stebuklas",
            Author="Jonas",
            Category="Linksma",
            Language="Lithuanian",
            PublicationDate=DateTime.Parse("1992-10-22T00:00:00"),
            ISBN="213213123456",
            reservedUntill=null,
            },
            };

            var Customers = new List<Customer> {
            new Customer{
            Name="Tomas",
            TakenBooks=new List<Book>{
            new Book{
            Name="Stebuklas",
            Author="Jonas",
            Category="Linksma",
            Language="Lithuanian",
            PublicationDate=DateTime.Parse("1992-10-22T00:00:00"),
            ISBN="213213123456",
            reservedUntill=null,
            },
            }
            },
            };
            var jsonHandlerMock = new Mock<IJsonHandler>();
            jsonHandlerMock.Setup(jh => jh.ReturnAllBookDataFromJson()).Returns(Books);
            jsonHandlerMock.Setup(jh => jh.ReturnAllCustomerDataFromJson()).Returns(Customers);
            _jsonHandler = jsonHandlerMock.Object;
        }
        [TestMethod]
        public void printFilteredBooks() {
            var fc = new FilterCommands(_jsonHandler);
            try {
                fc.PrintFilteredBooks("Name");
                return;
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void printAllBooks()
        {
            var fc = new FilterCommands(_jsonHandler);
            try
            {
                fc.PrintAllBooks();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void printAvailableBooks()
        {
            var fc = new FilterCommands(_jsonHandler);
            try
            {
                fc.PrintAvailableBooks();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void printTakenBooks()
        {
            var fc = new FilterCommands(_jsonHandler);
            try
            {
                fc.PrintTakenBooks();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
