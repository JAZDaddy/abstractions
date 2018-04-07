using Abstractions.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.VeryAbstract.Providers
{
    /// <summary>
    /// The concrete implementation of IPairwiseValue for strings.
    /// </summary>
    public class PairwiseStringItem : IPairwiseValue<string>
    {
        /// <summary>
        /// The first string.
        /// </summary>
        public string x { get; set; }
        /// <summary>
        /// The second string.
        /// </summary>
        public string y { get; set; }
    }
}
