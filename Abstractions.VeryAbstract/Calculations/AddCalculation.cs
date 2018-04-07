using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.VeryAbstract.Calculations
{
    /// <summary>
    /// The addition operation on doubles.
    /// </summary>
    public class AddCalculation : ICalculation<double>
    {
        /// <summary>
        /// Adds two doubles.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        /// <returns>The sum.</returns>
        public async Task<double> CalculateAsync(double x, double y)
        {
            return await Task.Run(() => x + y);
        }

        /// <summary>
        /// Returns a string description of the addition operation.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        /// <returns>A string which describes the addition operation.</returns>
        public async Task<string> GetCalculationResultAsync(double x, double y)
        {
            return $"The result of {x} + {y} = {await CalculateAsync(x, y)}.";
        }
    }
}
