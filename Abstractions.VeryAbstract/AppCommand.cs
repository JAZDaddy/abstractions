using System;
using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.VeryAbstract
{
    /// <summary>
    /// The concrete implementation of the generic AppCommand interface. The provided type aligns the ICalculation
    /// and IPariwseFileProvider implementations with the provided type, so they're all going to be operating on the
    /// same types.
    /// </summary>
    /// <typeparam name="T">The type on which the ICalculation and IPairwiseFileProvider interfaces will operate.</typeparam>
    public class AppCommand<T> : IAppCommand<T>
    {
        #region Private properties
        /// <summary>
        /// The ICalculation instance provided at object construction.
        /// </summary>
        private ICalculation<T> Calculation { get; set; }

        /// <summary>
        /// The IPairwiseFileProvider instance provided at object construction
        /// </summary>
        private IPairwiseFileProvider<T> PairwiseFileProvider { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// The constructor for dependency injection.
        /// </summary>
        /// <param name="calculation">The ICalculation instance to be invoked by the AppCommand.</param>
        /// <param name="pairwiseFileProvider">The IPairwiseFileProvider implementation which will provide pairs for calculation.</param>
        public AppCommand(ICalculation<T> calculation, IPairwiseFileProvider<T> pairwiseFileProvider) 
        {
            Calculation = calculation;
            PairwiseFileProvider = pairwiseFileProvider;
        }
        #endregion

        #region IAppCommand<T>
        /// <summary>
        /// Performs the calculations on the list of pairs from the embedded resource.
        /// </summary>
        /// <returns>The string results of the calculations.</returns>
        public async Task<string> ExecAsync()
        {
            var sb = new System.Text.StringBuilder();
            var numericFile = await PairwiseFileProvider.GetFileAsync();
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
        #endregion
    }
}
