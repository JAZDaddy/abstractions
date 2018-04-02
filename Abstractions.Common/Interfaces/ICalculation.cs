using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    public interface ICalculation
    {
        Task<double> Calculate(double x, double y);
        Task<string> GetCalculationResult(double x, double y);
    }
}
