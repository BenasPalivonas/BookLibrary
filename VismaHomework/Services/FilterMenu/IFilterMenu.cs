using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaHomework.Services.Filter
{
    interface IFilterMenu
    {
        public void PrintAllFilterCommands();
        public void ReadAndExecute();
    }
}
