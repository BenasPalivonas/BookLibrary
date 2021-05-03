using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;
using VismaHomework.Enums;
using VismaHomework.EnumExtensions;
using System.Linq;
using VismaHomework.Services.ConsoleWriter;
using VismaHomework.Services.Commands;

namespace VismaHomework.Services.Menu
{
    class Menu : IMenu
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ICommands _commands;

        public Menu(IConsoleWriter consoleWriter, ICommands commands)
        {
            _consoleWriter = consoleWriter;
            _commands = commands;
        }
        public void PrintCommands()
        {
            var allComands = Enum.GetValues(typeof(CommandsEnum)).Cast<CommandsEnum>();
            Console.WriteLine("List of commands: ");
            foreach (var command in allComands)
            {
                _consoleWriter.Write($"{command}: {command.ToDescriptionStringCommands()}");
            }
            ReadAndExecuteCommand();
        }
        public void ReadAndExecuteCommand()
        {
            try
            {
                _consoleWriter.Write("Enter your command");
                var command = _consoleWriter.Read();

                switch (command.ToLower())
                {
                    case "show":
                        _consoleWriter.WriteBooksTable();
                        break;
                    case "add":
                        _commands.AddBookToJson();
                        break;
                    case "take":
                        _commands.TakeBook();
                        break;
                    case "return":
                        _commands.returnBook();
                        break;
                    case "delete":
                        _commands.RemoveBookFromJson();
                        break;
                    case "exit":
                        _commands.EndProgram();
                        break;
                    default:
                        throw new ArgumentException("this command doesn't exsist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _consoleWriter.Write("Press any key to continue");
            _consoleWriter.Read();
            _consoleWriter.ClearConsole();
        }

    }
}
