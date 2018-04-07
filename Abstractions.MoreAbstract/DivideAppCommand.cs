using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Abstractions.MoreAbstract.Providers;
using System;

namespace Abstractions.MoreAbstract
{
    public class DivideAppCommand : AbstractAppCommand<double, NumericFile>
    {
        public DivideAppCommand()
        {
        }

        protected override ICalculation<double> GetCalculation()
        {
            return new Calculations.DivideCalculation();
        }
    }
}
