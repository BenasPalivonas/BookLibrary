using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Entities;

namespace VismaHomework.Services.FilterCommands
{
   public interface IFilterCommands
    {
        public void PrintFilteredBooks(string filterBy);
        public void PrintAllBooks();
        public void PrintTakenBooks();
        public void PrintAvailableBooks();
    }
}
