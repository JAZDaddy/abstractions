using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.VeryAbstract.Calculations
{
    /// <summary>
    /// The multiplication operation on doubles.
    /// </summary>
    public class MultiplyCalculation : ICalculation<double>
    {
        /// <summary>
        /// The multiplication calculation on doubles.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        /// <returns>The product.</returns>
        public async Task<double> CalculateAsync(double x, double y)
        {
            return await Task.Run(() => x * y);
        }

        /// <summary>
        /// Returns a string that describes the multiplication operation.
        /// </summary>
        /// <param name="x">The first operand.</param>
        /// <param name="y">The second operand.</param>
        /// <returns>The string which describes the multiplication operation.</returns>
        public async Task<string> GetCalculationResultAsync(double x, double y)
        {
            return $"The result of {x} * {y} = {await CalculateAsync(x, y)}.";
        }
    }
}
