using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Newtonsoft.Json;

namespace Abstractions.MultipleFullyConcrete
{
    /// <summary>
    /// Subtract app command.
    /// </summary>
    public class SubtractAppCommand : IAppCommand
    {
        /// <summary>
        /// Exec the specified args.
        /// </summary>
        /// <returns>A string containing the results of the execution</returns>
        public async Task<string> Exec()
        {
            var sb = new System.Text.StringBuilder();

            // get some data from our JSON data store
            var assembly = this.GetType().Assembly;

            NumericFile resultObject = null;
            using (var textStream = assembly.GetManifestResourceStream("Abstractions.MultipleFullyConcrete.SourceData.Numerics.txt"))
            {
                using (var streamReader = new StreamReader(textStream))
                {
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var deserializer = new JsonSerializer();
                        resultObject = deserializer.Deserialize<NumericFile>(jsonReader);
                    }
                }
            }

            // load up a list of values
            var itemList = new List<(double x, double y)>();
            foreach (var item in resultObject.data)
            {
                itemList.Add((item.x, item.y));
            }

            // process the values
            foreach (var item in itemList)
            {
                var doubleResult = await Task.Run(() => item.x - item.y);
                sb.AppendLine($"The result of {item.x} - {item.y} = {doubleResult}.");
            }

            // return the results as a string
            return sb.ToString();
        }
    }
}
