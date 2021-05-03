using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using VismaHomework.Services.JsonHandler;
using VismaHomework.Services.Menu;
using VismaHomework.Services.ConsoleWriter;
using VismaHomework.Services.Commands;
using VismaHomework.Services.Filter;
using VismaHomework.Services.FilterCommands;
using VismaHomework.Services.FilterCommands.cs;

namespace VismaHomework
{
    class Program
    {
        private readonly IMenu _menu;

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }


        public Program(IMenu menu)
        {
            _menu = menu;
        }
        public void Run()
        {
            Console.WriteLine("Welcome");
            while (true)
            {
                _menu.PrintCommands();
                Console.Clear();
            }
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<IJsonHandler, JsonHandler>();
                    services.AddTransient<IMenu, Menu>();
                    services.AddTransient<ICommands, Commands>();
                    services.AddTransient<IConsoleWriter, ConsoleWriter>();
                    services.AddTransient<IFilterMenu, FilterMenu>();
                    services.AddTransient<IFilterCommands, FilterCommands>();
                });
        }
    }
}
