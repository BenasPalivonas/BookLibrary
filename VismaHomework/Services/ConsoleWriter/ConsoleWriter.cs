using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Entities;
using VismaHomework.Services.Filter;
using VismaHomework.Services.JsonHandler;

namespace VismaHomework.Services.ConsoleWriter
{
    class ConsoleWriter : IConsoleWriter
    {
        private readonly IFilterMenu _filterMenu;

        public ConsoleWriter(IFilterMenu filterMenu) {
            _filterMenu = filterMenu;
        }
        public string Read()
        {
           var text=Console.ReadLine();
           return text;
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
        }
        public void ClearConsole() {
            Console.Clear();
        }
        public void WriteBooksTable() 
        {
            _filterMenu.PrintAllFilterCommands();
        }
        public Book GetBookData() {
            var newBook = new Book();
            PropertyInfo[] properties = typeof(Book).GetProperties();
            foreach (PropertyInfo property in properties)
            {
             
                if (property.Name == "PublicationDate")
                {
                    Write($"Enter a date (eg.10/22/1992): ");
                    var inputDate = DateTime.Parse(Read());
                    newBook.GetType().GetProperty(property.Name).SetValue(newBook, inputDate);
                }
                else if (property.Name == "reservedUntill")
                {
                    continue;
                }
                else
                {
                    Write($"Enter {property.Name}");
                    var prop = Read();
                    newBook.GetType().GetProperty(property.Name).SetValue(newBook, prop);
                }
               
              
            }
            return newBook;
        }
    }
}
