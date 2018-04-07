using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    /// <summary>
    /// Describes a calculation on a given type.
    /// </summary>
    /// <typeparam name="T">The type on which this calculation operates.</typeparam>
    public interface ICalculation<T>
    {
        /// <summary>
        /// Perfoms a calculation operation, assuming the operation is closed on its target type.
        /// </summary>
        /// <param name="x">The first operand of the calculation.</param>
        /// <param name="y">The second operand of the calculation.</param>
        /// <returns></returns>
        Task<T> CalculateAsync(T x, T y);

        /// <summary>
        /// Performs a calculation operation and returns a string value describing its result.
        /// </summary>
        /// <param name="x">The first operand of the calculation.</param>
        /// <param name="y">The second operand of the calculation.</param>
        /// <returns></returns>
        Task<string> GetCalculationResultAsync(T x, T y);
    }
}
