using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.VeryAbstract.Providers
{
    /// <summary>
    /// An implementation of IPairwiseNumericFileProvider, which in turn implements IPairwiseFileProvider for doubles
    /// </summary>
    public class PairwiseNumericFileProvider : IPairwiseNumericFileProvider
    {
        #region Private properties
        /// <summary>
        /// Private backing store for the assembly passed in via the constructor.
        /// </summary>
        private System.Reflection.Assembly Assembly { get; set; }
        /// <summary>
        /// Private backing store for the resource ID passed in via the constructor.
        /// </summary>
        private string ResourceId { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public PairwiseNumericFileProvider() { }
        /// <summary>
        /// The constructor for dependency injection.
        /// </summary>
        /// <param name="assembly">The assembly which contains the embedded resource.</param>
        /// <param name="resourceId">The resource ID for the embedded resource.</param>
        public PairwiseNumericFileProvider(System.Reflection.Assembly assembly, string resourceId) => (Assembly, ResourceId) = (assembly, resourceId);
        #endregion

        #region IPairwiseNumericFileProvider
        /// <summary>
        /// The interface method for accessing the file object.
        /// </summary>
        /// <returns>An instance of IPairwiseValueFile for doubles.</returns>
        public async Task<IPairwiseValueFile<double>> GetFileAsync() => await GetFileAsync(Assembly, ResourceId);

        /// <summary>
        /// The internal implementation which takes the assembly and resource ID (provided at construction)
        /// and deserializes the contents into a NumericFile object.
        /// </summary>
        /// <param name="resourceAssembly"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        protected async Task<IPairwiseValueFile<double>> GetFileAsync(Assembly resourceAssembly, string resourceId)
        {
            return await Task.Run(() =>
            {
                var assembly = resourceAssembly;
                using (var textStream = assembly.GetManifestResourceStream(resourceId))
                {
                    var deserializer = new JsonSerializer();
                    using (var jsonReader = new JsonTextReader(new StreamReader(textStream)))
                    {

                        var resultObject = deserializer.Deserialize<NumericFile>(jsonReader);
                        return resultObject;
                    }
                }
            });
        }
        #endregion
    }
}
