using System;
using System.Collections.Generic;
using System.Text;
using VismaHomework.Entities;
using VismaHomework.Models;

namespace VismaHomework.Services.JsonHandler
{
  public interface IJsonHandler
    {
        public List<Book> ReturnAllBookDataFromJson();
        public void UpdateBookJson(List<Book> bookList);
        public List<Customer> ReturnAllCustomerDataFromJson();
        public void UpdateCustomerJson(List<Customer> customerList);
    }
}
