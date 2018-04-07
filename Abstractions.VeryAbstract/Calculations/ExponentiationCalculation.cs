using System;
using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.VeryAbstract.Calculations
{
    /// <summary>
    /// The exponentiation operation on doubles.
    /// </summary>
    public class ExponentiationCalculation : ICalculation<double>, IDescribable
    {
        #region IDescribable
        /// <summary>
        /// Describes the calculation.
        /// </summary>
        public string Description => "The ExponentiationCalculation is IDescribable.";
        #endregion

        #region ICalculation<double>
        /// <summary>
        /// Performs the exponentiation calculation on doubles.
        /// </summary>
        /// <param name="x">The base.</param>
        /// <param name="y">The exponent.</param>
        /// <returns>The power.</returns>
        public async Task<double> CalculateAsync(double x, double y)
        {
            return await Task.Run(() => Math.Pow(x, y));
        }

        /// <summary>
        /// Returns a string description of the exponentiation operation.
        /// </summary>
        /// <param name="x">The base.</param>
        /// <param name="y">The exponent.</param>
        /// <returns>The string description of the exponentiation operation</returns>
        public async Task<string> GetCalculationResultAsync(double x, double y)
        {
            return $"The result of {x}^{y} = {await CalculateAsync(x, y)}";
        }
        #endregion
    }
}
