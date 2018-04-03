﻿using System.Collections.Generic;
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
    public class AppCommand : IAppCommand
    {
        /// <summary>
        /// Exec the specified args.
        /// </summary>
        /// <returns>A string containing the results of the execution</returns>
        public async Task<string> Exec()
        {
            var sb = new System.Text.StringBuilder();

            // get some data from our JSON data store
            var assembly = typeof(Abstractions.FullyConcrete.AppCommand).GetTypeInfo().Assembly;
            var textStream = assembly.GetManifestResourceStream("Abstractions.FullyConcrete.SourceData.Numerics.txt");
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
                var doubleResult = await Task.Run(() => item.x + item.y);
                sb.AppendLine($"The result of {item.x} + {item.y} = {doubleResult}.");
            }

            // return the results as a string
            return sb.ToString();
        }
    }
}
