using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Abstractions.Common.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.VeryAbstract.Providers
{
    /// <summary>
    /// An object which implements the IPairwiseValueFile interface for strings, such as one
    /// deserialized from a JSON file.
    /// </summary>
    public class PairwiseStringFile : IPairwiseValueFile<string>
    {
        /// <summary>
        /// An enumerable of IPairwiseValue implementations for strings. When deserialized from JSON,
        /// a list of instances of PairwiseStringItem will be instantiated.
        /// </summary>
        [JsonConverter(typeof(ConcreteConverter<List<PairwiseStringItem>>))]
        public IEnumerable<IPairwiseValue<string>> data { get; set;  }
    }
}
