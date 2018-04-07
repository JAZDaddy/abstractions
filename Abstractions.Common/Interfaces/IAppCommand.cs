using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    /// <summary>
    /// Describes an object that executes a simple operation without input parameters
    /// and returns a string with async/await semantics.
    /// </summary>
    public interface IAppCommand
    {
        Task<string> ExecAsync();
    }

    /// <summary>
    /// Describes an object that executes a simple operation without input parameters
    /// and returns a string with async/await semantics.
    /// </summary>
    /// <typeparam name="T">The type on which the performed operation in this class will act.</typeparam>
    public interface IAppCommand<T> : IAppCommand
    {
    }
}
