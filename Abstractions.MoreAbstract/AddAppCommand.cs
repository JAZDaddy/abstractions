using System;
namespace Abstractions.MoreAbstract
{
    public class AddAppCommand : AbstractAppCommand
    {
        public AddAppCommand()
        {
            this.Calculation = new Calculations.AddCalculation();
        }
    }
}
