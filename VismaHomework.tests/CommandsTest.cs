using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using VismaHomework.Entities;
using VismaHomework.Models;
using VismaHomework.Services.Commands;
using VismaHomework.Services.ConsoleWriter;
using VismaHomework.Services.JsonHandler;

namespace VismaHomework.tests
{
    [TestClass]
    public class CommandsTest
    {
        
    private IJsonHandler _jsonHandler;
    private IConsoleWriter _consoleWriter;
        [TestInitialize]
        public void Setup()
        {
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
            var Book = new Book
            {
                Name = "Pasaulis",
                Author = "Martynas",
                Category = "Mokslo",
                Language = "Lithuanian",
                PublicationDate = DateTime.Parse("2000-10-22T00:00:00"),
                ISBN = "213213123456",
                reservedUntill = null,
            };
            
            var jsonHandlerMock = new Mock<IJsonHandler>();

            jsonHandlerMock.Setup(jh => jh.ReturnAllBookDataFromJson()).Returns(Books);
           jsonHandlerMock.Setup(jh => jh.ReturnAllCustomerDataFromJson()).Returns(Customers);
           _jsonHandler = jsonHandlerMock.Object;
            var consoleWriterMock = new Mock<IConsoleWriter>();
           consoleWriterMock.Setup(cw => cw.GetBookData()).Returns(Book);
           consoleWriterMock.Setup(cw => cw.Read()).Returns("");  
           _consoleWriter = consoleWriterMock.Object;
           
        }
        
        
       [TestMethod]
        public void AddBookToJson()
        {
           var cm = new Commands(_jsonHandler, _consoleWriter);
            try {
                cm.AddBookToJson();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void TakeBook()
        {
            var cm = new Commands(_jsonHandler, _consoleWriter);
            try
            {
                cm.TakeBook();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void ReturnBook()
        {
           var cm = new Commands(_jsonHandler, _consoleWriter);
            try
            {
                cm.returnBook();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
