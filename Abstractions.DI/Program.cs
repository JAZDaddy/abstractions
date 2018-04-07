using Autofac;
using System;
using Abstractions.VeryAbstract;
using Abstractions.Common.Interfaces;
using Abstractions.VeryAbstract.Calculations;
using Abstractions.Common.Constants;
using Abstractions.VeryAbstract.Providers;
using System.Threading.Tasks;

namespace Abstractions.DI
{
    public class Program
    {
        private static IContainer Container { get; set; }

        static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            #region Register Calculations
            builder.RegisterType<AddCalculation>().Named<ICalculation<double>>(CalculationTypeNames.Add).InstancePerLifetimeScope();
            builder.RegisterType<SubtractCalculation>().Named<ICalculation<double>>(CalculationTypeNames.Subtract).InstancePerLifetimeScope();
            builder.RegisterType<MultiplyCalculation>().Named<ICalculation<double>>(CalculationTypeNames.Multiply).InstancePerLifetimeScope();
            builder.RegisterType<DivideCalculation>().Named<ICalculation<double>>(CalculationTypeNames.Divide).InstancePerLifetimeScope();
            builder.RegisterType<ExponentiationCalculation>().Named<ICalculation<double>>(CalculationTypeNames.Exponentiation).InstancePerLifetimeScope();
            builder.RegisterType<ConcatenateCalculation>().As<ICalculation<string>>().InstancePerLifetimeScope();
            #endregion
            #region Register PairwiseFileProviders
            builder.RegisterType<PairwiseNumericFileProvider>().As<IPairwiseFileProvider<double>>().InstancePerDependency();
            builder.RegisterType<PairwiseStringFileProvider>().As<IPairwiseFileProvider<string>>().InstancePerDependency();
            #endregion
            #region Register AppCommand variants
            builder.RegisterType<AppCommand<double>>().As<IAppCommand<double>>().InstancePerDependency();
            builder.RegisterType<AppCommand<string>>().As<IAppCommand<string>>().InstancePerDependency();
            #endregion

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
                            CalculationTypeNames.Exponentiation,
                            CalculationTypeNames.Concatenation
                        };

                        if (menuSelection > 0 && menuSelection <= typeNameMap.Length)
                        {
                            typeName = typeNameMap[menuSelection - 1];
                        }
                        else if (menuSelection == 0)
                        {
                            typeName = "STOP";
                        }
                        else
                        {
                            Console.WriteLine("Wut?");
                        }

                        if (typeName == "STOP")
                        {
                            Console.WriteLine("Fine. Be that way.");
                            exitLoop = true;
                        }
                        else if (typeName == CalculationTypeNames.Concatenation)
                        {
                            var appCommand = AppCommandFactory.GetAppCommand<string>(scope, typeName);
                            var retval = await appCommand.ExecAsync();
                            Console.WriteLine($"appCommand output:\r\n{retval}");
                        }
                        else if (typeName != string.Empty)
                        {
                            var appCommand = AppCommandFactory.GetAppCommand<double>(scope, typeName);
                            var retval = await appCommand.ExecAsync();
                            Console.WriteLine($"appCommand output:\r\n{retval}");
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
            Console.WriteLine(" 6) VeryAbstract (string concatenation)");
            Console.WriteLine();
            Console.WriteLine(" 0) Exit");
            Console.WriteLine("---------------------------------------");
            Console.Write("Make your choice: ");
        }
    }
}
