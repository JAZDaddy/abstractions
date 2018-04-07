using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Newtonsoft.Json;

namespace Abstractions.FullyConcrete
{
    /// <summary>
    /// App command.
    /// The AppCommand class is a simple class that implements the IAppCommand interface,
    /// which anticipates what this VERY GENERALIZED set of objects will do -- they take
    /// a simple action based on a set of input parameters, and describe their parameter
    /// expectations with a Usage method.
    /// </summary>
    public class AppCommand : IAppCommand<double>
    {
        /// <summary>
        /// Exec the specified args.
        /// </summary>
        /// <returns>A string containing the results of the execution</returns>
        public async Task<string> ExecAsync()
        {
            var sb = new System.Text.StringBuilder();

            // get some data from our JSON data store
            var assembly = this.GetType().Assembly;

            NumericFile resultObject = null;
            foreach (var s in assembly.GetManifestResourceNames())
            {
                Console.WriteLine(s);
            }

            using (var textStream = assembly.GetManifestResourceStream("Abstractions.FullyConcrete.SourceData.Numerics.txt"))
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

            // process the values
            foreach (var item in resultObject.data)
            {
                var result = await Task.Run(() => item.x + item.y);
                sb.AppendLine($"The result of {item.x} + {item.y} = {result}.");
            }

            // return the results as a string
            return sb.ToString();
        }
    }
}
