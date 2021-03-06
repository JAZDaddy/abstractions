﻿using System;
using System.Threading.Tasks;
using Abstractions.Common.Interfaces;
using Abstractions.MoreAbstract.Calculations;
using Abstractions.MoreAbstract.Providers;

namespace Abstractions.MoreAbstract
{
    public class ExponentiationAppCommand : IAppCommand<double>
    {
        protected ICalculation<double> Calculation { get; set; }
        protected INumericFileProvider NumericFileProvider { get; set;  }

        public ExponentiationAppCommand()
        {
            NumericFileProvider = new NumericFileProvider(this.GetType().Assembly, "Abstractions.MoreAbstract.SourceData.Numerics.txt");
            Calculation = new ExponentiationCalculation();
        }

        public async Task<string> ExecAsync()
        {
            var sb = new System.Text.StringBuilder();
            var numericFile = await NumericFileProvider.GetNumericFileAsync();

            foreach (var item in numericFile.data)
            {
                sb.AppendLine(await Calculation.GetCalculationResultAsync(item.x, item.y));
            }

            return sb.ToString();
        }
    }
}
