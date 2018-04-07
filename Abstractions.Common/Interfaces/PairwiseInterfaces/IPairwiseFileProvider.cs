using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    /// <summary>
    /// A generic interface that describes teh 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPairwiseFileProvider<T>
    {
        /// <summary>
        /// Returns the requested IPairwiseValueFile for the specified type from the embedded string resource
        /// identified at object construction.
        /// </summary>
        /// <returns>An implementation of IPairwiseValueFile<typeparamref name="T"/></returns>
        Task<IPairwiseValueFile<T>> GetFileAsync();
    }
}
