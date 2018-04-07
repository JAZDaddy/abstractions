using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Common.Interfaces
{
    /// <summary>
    /// A generic interface describing an object which contains an arbitrarily long list of pairs of the requested type.
    /// </summary>
    /// <typeparam name="T">The requested type for the values stored in pairs in the enumerable.</typeparam>
    public interface IPairwiseValueFile<T>
    {
        /// <summary>
        /// The enumerable containing the individual pairs of values of the requested type.
        /// </summary>
        IEnumerable<IPairwiseValue<T>> data { get; }
    }
}
