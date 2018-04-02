using System;
namespace Abstractions.MoreAbstract
{
    public class SubtractAppCommand : AbstractAppCommand
    {
        public SubtractAppCommand()
        {
            this.Calculation = new Calculations.SubtractCalculation();
        }
    }
}
