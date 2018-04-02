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
        /// <param name="args">Arguments. This implementation does not require specific
        /// parameters, and any supplied parameters will be ignored.</param>
        public async Task<string> Exec(params string[] args)
        {
            var sb = new System.Text.StringBuilder();

            // get some data from our JSON data store
            var assembly = this.GetType().Assembly;
            var textStream = assembly.GetManifestResourceStream("Abstractions.MultipleFullyConcrete.SourceData.Numerics.txt");
            var deserializer = new JsonSerializer();
            var jsonReader = new JsonTextReader(new StreamReader(textStream));
            var resultObject = deserializer.Deserialize<NumericFile>(jsonReader);

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

        /// <summary>
        /// Usage describes the arguments and expected return this instance.
        /// </summary>
        /// <returns>The usage details.</returns>
        public string Usage()
        {
            return "No args values are required; any supplied values will be ignored.";
        }
    }
}
