using Abstractions.Common.Interfaces;
using System;

namespace Abstractions.MoreAbstract
{
    public class MultiplyAppCommand : AbstractAppCommand
    {
        public MultiplyAppCommand()
        {
        }

        protected override ICalculation GetCalculation()
        {
            return new Calculations.MultiplyCalculation();
        }
    }
}
