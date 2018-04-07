using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Newtonsoft.Json;

namespace Abstractions.MoreAbstract
{
    public abstract class AbstractAppCommand<T, D> : IAppCommand<T> where D: IPairwiseValueFile<T>, new()
    {
        protected abstract ICalculation<T> GetCalculation();

        public async Task<string> ExecAsync()
        {
            var sb = new System.Text.StringBuilder();

            // get some data from our JSON data store
            var assembly = this.GetType().Assembly;
            using (var textStream = assembly.GetManifestResourceStream("Abstractions.MoreAbstract.SourceData.Numerics.txt"))
            {
                var deserializer = new JsonSerializer();
                using (var jsonReader = new JsonTextReader(new StreamReader(textStream)))
                {
                    var resultObject = deserializer.Deserialize<D>(jsonReader);

                    // process the values
                    foreach (var item in resultObject.data)
                    {
                        sb.AppendLine(await GetCalculation().GetCalculationResultAsync(item.x, item.y));
                    }
                }
            }

            // return the results as a string
            return sb.ToString();
        }
    }
}
