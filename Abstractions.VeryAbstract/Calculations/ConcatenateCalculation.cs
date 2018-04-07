using Abstractions.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.VeryAbstract.Calculations
{
    /// <summary>
    /// An implementation if ICalculation on strings which concatenates the two inputs into a single comma-separated string
    /// </summary>
    public class ConcatenateCalculation : ICalculation<string>
    {
        /// <summary>
        /// The concatenation operation.
        /// </summary>
        /// <param name="x">The first string.</param>
        /// <param name="y">The second string, which will be concatenated to the first.</param>
        /// <returns>The concatenated string.</returns>
        public async Task<string> CalculateAsync(string x, string y)
        {
            return await Task.Run(() => $"{x}, {y}");
        }

        /// <summary>
        /// The string output of the concatenation operation.
        /// </summary>
        /// <param name="x">The first string.</param>
        /// <param name="y">The second string, whcih will be concatenated to the first.</param>
        /// <returns>The concatenated string, preceded by a ASCII art-style arrow.</returns>
        public async Task<string> GetCalculationResultAsync(string x, string y)
        {
            return $"--> {await CalculateAsync(x, y)}";
        }
    }
}
