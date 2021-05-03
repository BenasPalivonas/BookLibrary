using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Entities;

namespace VismaHomework.Services.ConsoleWriter
{
  public  interface IConsoleWriter
    {
        public void Write(string text);
        public string Read();
        public void ClearConsole();
        public void WriteBooksTable();
        public Book GetBookData();
    }
}
