using Abstractions.Common.Interfaces;
using System;

namespace Abstractions.MoreAbstract
{
    public class DivideAppCommand : AbstractAppCommand
    {
        public DivideAppCommand()
        {
        }

        protected override ICalculation GetCalculation()
        {
            return new Calculations.DivideCalculation();
        }
    }
}
