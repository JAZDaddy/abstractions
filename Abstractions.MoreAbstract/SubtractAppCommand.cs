using Abstractions.Common.Interfaces;
using System;

namespace Abstractions.MoreAbstract
{
    public class SubtractAppCommand : AbstractAppCommand
    {
        public SubtractAppCommand()
        {
        }

        protected override ICalculation GetCalculation()
        {
            return new Calculations.SubtractCalculation();
        }
    }
}
