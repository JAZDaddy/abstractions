using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.VeryAbstract.Calculations
{
    /// <summary>
    /// The subtraction operation on doubles.
    /// </summary>
    public class SubtractCalculation : ICalculation<double>
    {
        /// <summary>
        /// Returns the result of the subtraction operation.
        /// </summary>
        /// <param name="x">The minuend.</param>
        /// <param name="y">The subtrahend.</param>
        /// <returns>The difference.</returns>
        public async Task<double> CalculateAsync(double x, double y)
        {
            return await Task.Run(() => x - y);
        }

        /// <summary>
        /// Returns a string which describes the subtraction operation.
        /// </summary>
        /// <param name="x">The minuend.</param>
        /// <param name="y">The subtrahend.</param>
        /// <returns>The string which describes the subtraction operation.</returns>
        public async Task<string> GetCalculationResultAsync(double x, double y)
        {
            return $"The result of {x} - {y} = {await CalculateAsync(x, y)}.";
        }
    }
}
