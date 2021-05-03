using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaHomework.Services.Commands
{
    public interface ICommands
    {
        public void AddBookToJson();
        public void RemoveBookFromJson();
        public void TakeBook();
        public void returnBook();
        public void EndProgram();
    }
}
