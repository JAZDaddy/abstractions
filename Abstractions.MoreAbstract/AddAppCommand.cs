using Abstractions.Common;
using Abstractions.Common.Interfaces;
using Abstractions.MoreAbstract.Providers;
using System;

namespace Abstractions.MoreAbstract
{
    public class AddAppCommand : AbstractAppCommand<double, NumericFile>
    {
        public AddAppCommand()
        {
        }

        protected override ICalculation<double> GetCalculation()
        {
            return new Calculations.AddCalculation();
        }
    }
}
