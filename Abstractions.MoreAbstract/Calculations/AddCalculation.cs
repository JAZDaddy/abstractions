using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.MoreAbstract.Calculations
{
    public class AddCalculation : ICalculation
    {
        public async Task<double> Calculate(double x, double y)
        {
            return await Task.Run(() => x + y);
        }

        public async Task<string> GetCalculationResult(double x, double y)
        {
            return $"The result of {x} + {y} = {await Calculate(x, y)}.";
        }
    }
}
