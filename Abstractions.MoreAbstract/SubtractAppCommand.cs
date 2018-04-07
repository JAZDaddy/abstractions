using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Abstractions.MoreAbstract.Providers;
using System;

namespace Abstractions.MoreAbstract
{
    public class SubtractAppCommand : AbstractAppCommand<double, NumericFile>
    {
        public SubtractAppCommand()
        {
        }

        protected override ICalculation<double> GetCalculation()
        {
            return new Calculations.SubtractCalculation();
        }
    }
}
