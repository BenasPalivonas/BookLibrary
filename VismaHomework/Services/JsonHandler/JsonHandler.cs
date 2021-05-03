using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using VismaHomework.Entities;
using VismaHomework.Models;

namespace VismaHomework.Services.JsonHandler
{

    public class JsonHandler : IJsonHandler
    {
        private readonly string _pathBooks = AppDomain.CurrentDomain.BaseDirectory+@"..\..\..\..\\JsonData\\Books.json";
        private readonly string _pathCustomers = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\\JsonData\\Customers.json";
        public List<Book> ReturnAllBookDataFromJson()
        {
            string booksFromFile;
            using (var reader = new StreamReader(_pathBooks))
            {
                booksFromFile = reader.ReadToEnd();
            }
            List<Book> Books = JsonConvert.DeserializeObject<List<Book>>(booksFromFile);
            return Books;
        }
        public void UpdateBookJson(List<Book> bookList)
        {
            try
            {
                if (bookList == null) {
                    throw new Exception("Error updating");
                }
                var booksToWrite = JsonConvert.SerializeObject(bookList, Formatting.Indented);
                using (var writer = new StreamWriter(_pathBooks))
                {
                    writer.Write(booksToWrite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Customer> ReturnAllCustomerDataFromJson()
        {
            string customersFromFile;
            using (var reader = new StreamReader(_pathCustomers))
            {
                customersFromFile = reader.ReadToEnd();
            }
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(customersFromFile);
            return customers;
        }
        public void UpdateCustomerJson(List<Customer> customerList)
        {
            try
            {
                if (customerList == null)
                {
                    throw new Exception("Error updating");
                }
                var customersToWrite = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                using (var writer = new StreamWriter(_pathCustomers))
                {
                    writer.Write(customersToWrite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

