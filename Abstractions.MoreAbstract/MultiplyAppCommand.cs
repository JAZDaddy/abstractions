using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Abstractions.MoreAbstract.Providers;
using System;

namespace Abstractions.MoreAbstract
{
    public class MultiplyAppCommand : AbstractAppCommand<double, NumericFile>
    {
        public MultiplyAppCommand()
        {
        }

        protected override ICalculation<double> GetCalculation()
        {
            return new Calculations.MultiplyCalculation();
        }
    }
}
