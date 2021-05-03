using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Enums;
using VismaHomework.Services.ConsoleWriter;
using VismaHomework.EnumExtensions;
using VismaHomework.Services.FilterCommands;

namespace VismaHomework.Services.Filter
{
    class FilterMenu : IFilterMenu
    {
        private readonly IFilterCommands _filterCommands;
        public FilterMenu(IFilterCommands filterCommands) {
            _filterCommands = filterCommands;
        }
        public void PrintAllFilterCommands() {
            var allFilterComands = Enum.GetValues(typeof(FilterEnum)).Cast<FilterEnum>();
            Console.Clear();
            Console.WriteLine("List of commands: ");
            foreach (var command in allFilterComands)
            {
                Console.WriteLine ($"{command}: {command.ToDescriptionStringFilter()}");
            }
            ReadAndExecute();
        }
        public void ReadAndExecute() {
            try
            {   
                Console.WriteLine("Enter your command");
                var command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "author":
                        _filterCommands.PrintFilteredBooks("Author");
                        break;
                    case "category":
                        _filterCommands.PrintFilteredBooks("Category");
                        break;
                    case "language":
                        _filterCommands.PrintFilteredBooks("Language");
                        break;
                    case "isbn":
                        _filterCommands.PrintFilteredBooks("ISBN");
                        break;
                    case "name":
                        _filterCommands.PrintFilteredBooks("Name");
                        break;
                    case "taken":
                        _filterCommands.PrintTakenBooks();
                        break;
                    case "available":
                        _filterCommands.PrintAvailableBooks();
                        break;
                    case "none":
                        _filterCommands.PrintAllBooks();
                        break;
                    default:
                        throw new ArgumentException("this command doesn't exsist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
   
        }
    }
    }

