using System;
using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    /// <summary>
    /// Describes an object that rehydrates a NumericFile object from an embedded resource.
    /// </summary>
    public interface INumericFileProvider
    {
        /// <summary>
        /// Retrieves a NumericFile object based on a previously cached Assembly and ResourceId.
        /// </summary>
        /// <returns>A NumericFile</returns>
        Task<NumericFile> GetNumericFileAsync();
        /// <summary>
        /// Retrieves a NumericFile object from an embedded resource.
        /// </summary>
        /// <param name="resourceAssembly">The assembly containing the embedded resource.</param>
        /// <param name="resourceId">The string resource ID of the embedded resource.</param>
        /// <returns></returns>
        Task<NumericFile> GetNumericFileAsync(System.Reflection.Assembly resourceAssembly, string resourceId);
    }
}
