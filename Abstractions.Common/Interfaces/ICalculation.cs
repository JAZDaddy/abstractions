using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    public interface ICalculation
    {
        Task<double> CalculateAsync(double x, double y);
        Task<string> GetCalculationResultAsync(double x, double y);
    }
}
