using System;
namespace Abstractions.MoreAbstract
{
    public class DivideAppCommand : AbstractAppCommand
    {
        public DivideAppCommand()
        {
            this.Calculation = new Calculations.DivideCalculation();
        }
    }
}
