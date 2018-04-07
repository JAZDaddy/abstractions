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
    /// An implementation of IPairwiseFileProvider for strings.
    /// </summary>
    public class PairwiseStringFileProvider : IPairwiseFileProvider<string>
    {
        #region Private properties
        /// <summary>
        /// The private backing store for the assembly provided at object construction.
        /// </summary>
        private System.Reflection.Assembly Assembly { get; set; }
        /// <summary>
        /// The private backing store for the resource ID provided at object construction.
        /// </summary>
        private string ResourceId { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public PairwiseStringFileProvider() { }

        /// <summary>
        /// The constructor for dependency injection.
        /// </summary>
        /// <param name="assembly">The assembly containing the embedded resource.</param>
        /// <param name="resourceId">The resource ID for the embedded resource.</param>
        public PairwiseStringFileProvider(System.Reflection.Assembly assembly, string resourceId) => (Assembly, ResourceId) = (assembly, resourceId);
        #endregion

        #region IPairwiseStringFileProvider
        /// <summary>
        /// The interface method for retrieving an instance of IPairwiseValueFile for strings given the values supplied at
        /// object construction.
        /// </summary>
        /// <returns>The IPairwiseValueFile instance for strings.</returns>
        public async Task<IPairwiseValueFile<string>> GetFileAsync() => await GetFileAsync(Assembly, ResourceId);

        /// <summary>
        /// The internal implementation for deserializing the IPairwiseValueFile instance for strings from the
        /// embedded resource.
        /// </summary>
        /// <param name="resourceAssembly">The assembly containing the embedded resource.</param>
        /// <param name="resourceId">The resource ID of the embedded resource.</param>
        /// <returns></returns>
        protected async Task<IPairwiseValueFile<string>> GetFileAsync(Assembly resourceAssembly, string resourceId)
        {
            return await Task.Run(() =>
            {
                var assembly = resourceAssembly;
                using (var textStream = assembly.GetManifestResourceStream(resourceId))
                {
                    var deserializer = new JsonSerializer();
                    using (var jsonReader = new JsonTextReader(new StreamReader(textStream)))
                    {

                        var resultObject = deserializer.Deserialize<PairwiseStringFile>(jsonReader);
                        return resultObject;
                    }
                }
            });
        }
        #endregion
    }
}
