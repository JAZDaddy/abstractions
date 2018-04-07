using Abstractions.Common.Interfaces;
using Abstractions.Common.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Abstractions.Common
{
    /// <summary>
    /// An object which describes a file containing pairs of doubles.
    /// </summary>
    public class NumericFile : IPairwiseValueFile<double>
    {
        /// <summary>
        /// An enumerable of pairs of doubles.
        /// </summary>
        [JsonConverter(typeof(ConcreteConverter<List<NumericItem>>))]
        public IEnumerable<IPairwiseValue<double>> data { get; set; }
    }
}
