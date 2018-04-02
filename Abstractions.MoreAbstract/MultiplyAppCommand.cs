using System;
namespace Abstractions.MoreAbstract
{
    public class MultiplyAppCommand : AbstractAppCommand
    {
        public MultiplyAppCommand()
        {
            this.Calculation = new Calculations.MultiplyCalculation();
        }
    }
}
