﻿using System;
using System.Threading.Tasks;
using Abstractions.Common.Interfaces;

namespace Abstractions.MoreAbstract.Calculations
{
    public class ExponentiationCalculation : ICalculation<double>
    {
        public async Task<double> CalculateAsync(double x, double y)
        {
            return await Task.Run(() => Math.Pow(x, y));
        }

        public async Task<string> GetCalculationResultAsync(double x, double y)
        {
            return $"The result of {x}^{y} = {await CalculateAsync(x, y)}";
        }
    }
}
