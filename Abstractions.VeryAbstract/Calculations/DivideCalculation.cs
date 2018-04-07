using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.VeryAbstract.Calculations
{
    /// <summary>
    /// The division operation on doubles.
    /// </summary>
    public class DivideCalculation : ICalculation<double>
    {
        /// <summary>
        /// Performs a division operation on doubles.
        /// </summary>
        /// <param name="x">The dividend.</param>
        /// <param name="y">The divisor.</param>
        /// <returns>The quotient.</returns>
        public async Task<double> CalculateAsync(double x, double y)
        {
            return await Task.Run(() => x / y);
        }

        /// <summary>
        /// Returns a string description of the division operation.
        /// </summary>
        /// <param name="x">The dividend.</param>
        /// <param name="y">The divisor.</param>
        /// <returns>A string description of the division operation.</returns>
        public async Task<string> GetCalculationResultAsync(double x, double y)
        {
            return $"The result of {x} / {y} = {await CalculateAsync(x, y)}.";
        }
    }
}
