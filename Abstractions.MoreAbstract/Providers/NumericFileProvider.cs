using System;
using System.IO;
using System.Threading.Tasks;
using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Newtonsoft.Json;

namespace Abstractions.MoreAbstract.Providers
{
    public class NumericFileProvider : INumericFileProvider
    {
        public async Task<NumericFile> GetNumericFile()
        {
            return await Task.Run(() =>
            {
                var assembly = this.GetType().Assembly;
                var textStream = assembly.GetManifestResourceStream("Abstractions.MoreAbstract.SourceData.Numerics.txt");
                var deserializer = new JsonSerializer();
                var jsonReader = new JsonTextReader(new StreamReader(textStream));
                var resultObject = deserializer.Deserialize<NumericFile>(jsonReader);
                return resultObject;
            });
        }
    }
}
