using System;
using System.Threading.Tasks;
using Abstractions.Common.Interfaces;
using Abstractions.MoreAbstract.Calculations;
using Abstractions.MoreAbstract.Providers;

namespace Abstractions.MoreAbstract
{
    public class ExponentiationAppCommand : IAppCommand
    {
        protected ICalculation Calculation { get; set; }
        protected INumericFileProvider NumericFileProvider { get; set;  }

        public ExponentiationAppCommand()
        {
            NumericFileProvider = new NumericFileProvider();
            Calculation = new ExponentiationCalculation();
        }

        public async Task<string> Exec(params string[] args)
        {
            var sb = new System.Text.StringBuilder();
            var numericFile = await NumericFileProvider.GetNumericFile();

            foreach (var item in numericFile.data)
            {
                sb.AppendLine(await Calculation.GetCalculationResult(item.x, item.y));
            }

            return sb.ToString();
        }

        public string Usage()
        {
            return "The ExponentiationCalculation takes no arguments; any supplied will be ignored.";
        }
    }
}
