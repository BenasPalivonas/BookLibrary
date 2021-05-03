using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VismaHomework.Entities;
using VismaHomework.Models;
using VismaHomework.Services.JsonHandler;

namespace VismaHomework.tests
{
    [TestClass]
    public class JsonHandlerTests
    {
        [TestMethod]
        public void ReadBooksFromJson()
        {
            var jh = new JsonHandler();
            try
            {
                var result = jh.ReturnAllBookDataFromJson();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void ReadCustomersFromJson()
        {
            var jh = new JsonHandler();
            try
            {
                var result = jh.ReturnAllCustomerDataFromJson();
                Assert.IsNotNull(result);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void UpdateBookJsonValid()
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
            var jh = new JsonHandler();
            try
            {
                jh.UpdateBookJson(Books);
                Assert.IsTrue(true);
            }

            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void UpdateBookJson_NullValueOfBooks()
        {
            var jh = new JsonHandler();
            var nullBooks = new List<Book> { null };
            try
            {
                jh.UpdateBookJson(nullBooks);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                jh.UpdateBookJson(null);
                Assert.Fail(ex.Message);

            }
        }
        [TestMethod]
        public void UpdateCustomerJson()
        {
            var Customer = new List<Customer> {
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
            var jh = new JsonHandler();
            try
            {
                jh.UpdateCustomerJson(Customer);
                Assert.IsTrue(true);
            }

            catch
            {
                Assert.IsTrue(false);
            }
        }
        [TestMethod]
        public void UpdateCustomerJson_NullValueOfCustomers()
        {
            var jh = new JsonHandler();
            var nullCustomer = new List<Customer> { null };
            try
            {
                jh.UpdateCustomerJson(nullCustomer);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                jh.UpdateBookJson(null);
                Assert.Fail(ex.Message);

            }
        }
    }
}
