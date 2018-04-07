using Abstractions.Common.Interfaces;
using System;
namespace Abstractions.Common
{
    /// <summary>
    /// An object that contains two double values.
    /// </summary>
    public class NumericItem : IPairwiseValue<double>
    {
        /// <summary>
        /// The first of the two doubles.
        /// </summary>
        public double x { get; set; }
        /// <summary>
        /// The second of the two doubles.
        /// </summary>
        public double y { get; set; }
    }
}
