using System;
using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.VeryAbstract
{
    public class AppCommand : IAppCommand
    {
        private ICalculation Calculation { get; set; }
        private INumericFileProvider NumericFileProvider { get; set; }

        public AppCommand(ICalculation calculation, INumericFileProvider numericFileProvider) 
        {
            Calculation = calculation;
            NumericFileProvider = numericFileProvider;
        }

        public async Task<string> ExecAsync()
        {
            var sb = new System.Text.StringBuilder();
            var numericFile = await NumericFileProvider.GetNumericFileAsync();
            foreach (var item in numericFile.data)
            {
                if (Calculation is IDescribable describableCalculation)
                {
                    sb.AppendLine($"The calculation says: {describableCalculation.Description}");
                }
                sb.AppendLine(await Calculation.GetCalculationResultAsync(item.x, item.y));
            }
            return sb.ToString();
        }
    }
}
