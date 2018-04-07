using System;
using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var appCommands = new Abstractions.Common.Interfaces.IAppCommand<double>[] {
                #region FullyConcrete
                // Our first implementation: very purpose-built
                new Abstractions.FullyConcrete.AppCommand(),
                #endregion
                #region MultipleFullyConcrete
                // Our second-generation implementations: clipboard inherited code 
                // from the original AppCommand, now in four delicious flavors
                new Abstractions.MultipleFullyConcrete.AddAppCommand(),
                new Abstractions.MultipleFullyConcrete.SubtractAppCommand(),
                new Abstractions.MultipleFullyConcrete.MultiplyAppCommand(),
                new Abstractions.MultipleFullyConcrete.DivideAppCommand(),
                #endregion
                #region MoreAbstract
                // The third generation: recognizing that we had a lot of
                // duplicate code, the implementations leverage an abstract base
                // class and an ICalculation Strategy Pattern implementation
                new Abstractions.MoreAbstract.AddAppCommand(),
                new Abstractions.MoreAbstract.SubtractAppCommand(),
                new Abstractions.MoreAbstract.MultiplyAppCommand(),
                new Abstractions.MoreAbstract.DivideAppCommand(),
                new Abstractions.MoreAbstract.ExponentiationAppCommand(),
                #endregion
                #region VeryAbstract
                new Abstractions.VeryAbstract.AppCommand<double>(new Abstractions.VeryAbstract.Calculations.AddCalculation(), new Abstractions.VeryAbstract.Providers.PairwiseNumericFileProvider(typeof(Abstractions.Common.NumericFile).Assembly, "Abstractions.Common.SourceData.Numerics.txt")),
                new Abstractions.VeryAbstract.AppCommand<double>(new Abstractions.VeryAbstract.Calculations.SubtractCalculation(), new Abstractions.VeryAbstract.Providers.PairwiseNumericFileProvider(typeof(Abstractions.Common.NumericFile).Assembly, "Abstractions.Common.SourceData.Numerics.txt")),
                new Abstractions.VeryAbstract.AppCommand<double>(new Abstractions.VeryAbstract.Calculations.MultiplyCalculation(), new Abstractions.VeryAbstract.Providers.PairwiseNumericFileProvider(typeof(Abstractions.Common.NumericFile).Assembly, "Abstractions.Common.SourceData.Numerics.txt")),
                new Abstractions.VeryAbstract.AppCommand<double>(new Abstractions.VeryAbstract.Calculations.DivideCalculation(), new Abstractions.VeryAbstract.Providers.PairwiseNumericFileProvider(typeof(Abstractions.Common.NumericFile).Assembly, "Abstractions.Common.SourceData.Numerics.txt")),
                new Abstractions.VeryAbstract.AppCommand<double>(new Abstractions.VeryAbstract.Calculations.ExponentiationCalculation(), new Abstractions.VeryAbstract.Providers.PairwiseNumericFileProvider(typeof(Abstractions.Common.NumericFile).Assembly, "Abstractions.Common.SourceData.Numerics.txt"))
                #endregion
            };

            var exitLoop = false;
            while (!exitLoop)
            {
                DisplayMenu();

                var input = Console.ReadLine();

                if (int.TryParse(input, out var menuSelection))
                {
                    IAppCommand<double> appCommand = null;

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
                        var retval = await appCommand.ExecAsync();
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
            Console.WriteLine("FullyAbstract");
            Console.WriteLine("=============");
            Console.WriteLine(" 1) FullyConcrete (add)");
            Console.WriteLine("MultipleFullyConcrete");
            Console.WriteLine("=====================");
            Console.WriteLine(" 2) MultipleFullyConcrete (add)");
            Console.WriteLine(" 3) MultipleFullyConcrete (subrtract)");
            Console.WriteLine(" 4) MultipleFullyConcrete (multiply)");
            Console.WriteLine(" 5) MultipleFullyConcrete (divide)");
            Console.WriteLine("MoreAbstract");
            Console.WriteLine("============");
            Console.WriteLine(" 6) MoreAbstract (add)");
            Console.WriteLine(" 7) MoreAbstract (subtract)");
            Console.WriteLine(" 8) MoreAbstract (multiply)");
            Console.WriteLine(" 9) MoreAbstract (divide)");
            Console.WriteLine("10) MoreAbstract (exponentiation)");
            Console.WriteLine("VeryAbstract");
            Console.WriteLine("============");
            Console.WriteLine("11) VeryAbstract (add)");
            Console.WriteLine("12) VeryAbstract (subtract)");
            Console.WriteLine("13) VeryAbstract (multiply)");
            Console.WriteLine("14) VeryAbstract (divide)");
            Console.WriteLine("15) VeryAbstract (exponentiation)");
            Console.WriteLine();
            Console.WriteLine(" 0) Exit");
            Console.WriteLine("---------------------------------------");
            Console.Write("Make your choice: ");
        }
    }
}
