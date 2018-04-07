using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.MoreAbstract.Providers
{
    public class PairwiseNumericFileProvider : IPairwiseNumericFileProvider
    {
        #region Private properties
        private System.Reflection.Assembly Assembly { get; set; }
        private string ResourceId { get; set; }
        #endregion

        #region Constructors
        public PairwiseNumericFileProvider() { }
        public PairwiseNumericFileProvider(System.Reflection.Assembly assembly, string resourceId) => (Assembly, ResourceId) = (assembly, resourceId);
        #endregion

        #region IPairwiseNumericFileProvider
        public async Task<IPairwiseValueFile<double>> GetFileAsync() => await GetFileAsync(Assembly, ResourceId);

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
