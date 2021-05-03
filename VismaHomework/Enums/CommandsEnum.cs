using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaHomework.Enums
{
    public enum CommandsEnum
    {
        [Description("Show all books")]
        Show,
        [Description("Add new book")]
        Add,
        [Description("Take a book from the library")]
        Take,
        [Description("Return a book")]
        Return,
        [Description("Delete a book")]
        Delete,
        [Description("End program")]
        Exit,
    }
}
