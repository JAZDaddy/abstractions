using System;
using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var appCommands = new Abstractions.Common.Interfaces.IAppCommand[] {
                new Abstractions.FullyConcrete.AppCommand(),
                new Abstractions.MultipleFullyConcrete.AddAppCommand(),
                new Abstractions.MultipleFullyConcrete.SubtractAppCommand(),
                new Abstractions.MultipleFullyConcrete.MultiplyAppCommand(),
                new Abstractions.MultipleFullyConcrete.DivideAppCommand(),
                new Abstractions.MoreAbstract.AddAppCommand(),
                new Abstractions.MoreAbstract.SubtractAppCommand(),
                new Abstractions.MoreAbstract.MultiplyAppCommand(),
                new Abstractions.MoreAbstract.DivideAppCommand()
            };

            var exitLoop = false;
            while (!exitLoop)
            {
                DisplayMenu();

                var input = Console.ReadLine();

                if (int.TryParse(input, out var menuSelection))
                {
                    IAppCommand appCommand = null;

                    if (menuSelection > 0 && menuSelection < appCommands.Length + 1)
                    {
                        appCommand = appCommands[menuSelection - 1];
                    }
                    else if (menuSelection == 0)
                    {
                        Console.WriteLine("Fine. Be that way.");
                        exitLoop = true;
                    }
                    else
                    {
                        Console.WriteLine("Wut?");
                    }

                    if (appCommand != null)
                    {
                        var retval = await appCommand.Exec();
                        Console.WriteLine($"appCommand output:\r\n{retval}");
                    }
                }
                else
                {
                    Console.WriteLine("Wut?");
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("AppCommand Test Harness:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1) FullyConcrete (add)");
            Console.WriteLine("2) MultipleFullyConcrete (add)");
            Console.WriteLine("3) MultipleFullyConcrete (subrtract)");
            Console.WriteLine("4) MultipleFullyConcrete (multiply)");
            Console.WriteLine("5) MultipleFullyConcrete (divide)");
            Console.WriteLine("6) MoreAbstract (add)");
            Console.WriteLine("7) MoreAbstract (subtract)");
            Console.WriteLine("8) MoreAbstract (multiply)");
            Console.WriteLine("9) MoreAbstract (divide)");
            Console.WriteLine();
            Console.WriteLine("0) Exit");
            Console.WriteLine("---------------------------------------");
            Console.Write("Make your choice: ");
        }
    }
}
