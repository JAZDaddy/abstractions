using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Newtonsoft.Json;

namespace Abstractions.MoreAbstract
{
    public abstract class AbstractAppCommand : IAppCommand
    {
        protected ICalculation Calculation { get; set; }

        public async Task<string> Exec()
        {
            var sb = new System.Text.StringBuilder();

            // get some data from our JSON data store
            var assembly = this.GetType().Assembly;
            var textStream = assembly.GetManifestResourceStream("Abstractions.MoreAbstract.SourceData.Numerics.txt");
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
                sb.AppendLine(await Calculation.GetCalculationResult(item.x, item.y));
            }

            // return the results as a string
            return sb.ToString();
        }
    }
}
