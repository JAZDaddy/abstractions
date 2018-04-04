using Autofac;
using System;
using Abstractions.Common;
using Abstractions.VeryAbstract;
using Abstractions.Common.Interfaces;
using Abstractions.VeryAbstract.Calculations;
using Abstractions.Common.Constants;
using Abstractions.VeryAbstract.Providers;
using Autofac.Core;
using System.Threading.Tasks;

namespace Abstractions.DI
{
    public class Program
    {
        private static IContainer Container { get; set; }

        static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AddCalculation>().Named<ICalculation>(CalculationTypeNames.Add).InstancePerLifetimeScope();
            builder.RegisterType<SubtractCalculation>().Named<ICalculation>(CalculationTypeNames.Subtract).InstancePerLifetimeScope();
            builder.RegisterType<MultiplyCalculation>().Named<ICalculation>(CalculationTypeNames.Multiply).InstancePerLifetimeScope();
            builder.RegisterType<DivideCalculation>().Named<ICalculation>(CalculationTypeNames.Divide).InstancePerLifetimeScope();
            builder.RegisterType<ExponentiationCalculation>().Named<ICalculation>(CalculationTypeNames.Exponentiation).InstancePerLifetimeScope();
            builder.RegisterType<NumericFileProvider>().As<INumericFileProvider>().InstancePerLifetimeScope();
            builder.RegisterType<AppCommand>().As<IAppCommand>().InstancePerDependency();

            Container = builder.Build();
        }

        static async Task Main(string[] args)
        {
            BuildContainer();

            using (var scope = Container.BeginLifetimeScope())
            {
                var exitLoop = false;
                while (!exitLoop)
                {
                    DisplayMenu();

                    var input = Console.ReadLine();

                    if (int.TryParse(input, out var menuSelection))
                    {
                        string typeName = string.Empty;

                        string[] typeNameMap =
                        {
                            CalculationTypeNames.Add,
                            CalculationTypeNames.Subtract,
                            CalculationTypeNames.Multiply,
                            CalculationTypeNames.Divide,
                            CalculationTypeNames.Exponentiation
                        };

                        if (menuSelection > 0 && menuSelection <= typeNameMap.Length)
                        {
                            typeName = typeNameMap[menuSelection - 1];
                        }
                        else if (menuSelection == 0)
                        {
                            typeName = "STOP";
                        }

                        if (!string.IsNullOrEmpty(typeName))
                        {
                            if (typeName == "STOP")
                            {
                                Console.WriteLine("Fine. Be that way.");
                                exitLoop = true;
                            }
                            else
                            {
                                var appCommand = AppCommandFactory.CreateAppCommand(scope, typeName);
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
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("AppCommand Test Harness:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" 1) VeryAbstract (add)");
            Console.WriteLine(" 2) VeryAbstract (subtract)");
            Console.WriteLine(" 3) VeryAbstract (multiply)");
            Console.WriteLine(" 4) VeryAbstract (divide)");
            Console.WriteLine(" 5) VeryAbstract (exponentiation)");
            Console.WriteLine();
            Console.WriteLine(" 0) Exit");
            Console.WriteLine("---------------------------------------");
            Console.Write("Make your choice: ");
        }
    }
}
