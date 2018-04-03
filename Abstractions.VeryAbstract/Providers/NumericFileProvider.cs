using System;
using System.IO;
using System.Threading.Tasks;
using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Newtonsoft.Json;

namespace Abstractions.VeryAbstract.Providers
{
    public class NumericFileProvider : INumericFileProvider
    {
        private System.Reflection.Assembly Assembly { get; set; }
        private string ResourceId { get; set; }

        private NumericFileProvider() { }

        public NumericFileProvider(System.Reflection.Assembly assembly, string resourceId) => (Assembly, ResourceId) = (assembly, resourceId);

        public async Task<NumericFile> GetNumericFileAsync() => await GetNumericFileAsync(Assembly, ResourceId);

        public async Task<NumericFile> GetNumericFileAsync(System.Reflection.Assembly resourceAssembly, string resourceId)
        {
            return await Task.Run(() =>
            {
                var assembly = resourceAssembly;
                var textStream = assembly.GetManifestResourceStream(resourceId);
                var deserializer = new JsonSerializer();
                var jsonReader = new JsonTextReader(new StreamReader(textStream));
                var resultObject = deserializer.Deserialize<NumericFile>(jsonReader);
                return resultObject;
            });
        }
    }
}
