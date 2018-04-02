using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    public interface IAppCommand
    {
        string Usage();
        Task<string> Exec(params string[] args);
    }
}
