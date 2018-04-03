using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    public interface IAppCommand
    {
        Task<string> Exec();
    }
}
