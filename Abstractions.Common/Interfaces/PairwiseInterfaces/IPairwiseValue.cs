using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Common.Interfaces
{
    /// <summary>
    /// A generic interface describing pairs of the requested type
    /// </summary>
    /// <typeparam name="T">The requested type for the stored values.</typeparam>
    public interface IPairwiseValue<T>
    {
        /// <summary>
        /// The first value.
        /// </summary>
        T x { get; set; }
        /// <summary>
        /// The second value.
        /// </summary>
        T y { get; set; }
    }
}
