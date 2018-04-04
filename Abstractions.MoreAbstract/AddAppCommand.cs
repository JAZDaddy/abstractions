using Abstractions.Common.Interfaces;
using System;

namespace Abstractions.MoreAbstract
{
    public class AddAppCommand : AbstractAppCommand
    {
        public AddAppCommand()
        {
        }

        protected override ICalculation GetCalculation()
        {
            return new Calculations.AddCalculation();
        }
    }
}
