using System;
using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    public interface INumericFileProvider
    {
        Task<NumericFile> GetNumericFileAsync();
        Task<NumericFile> GetNumericFileAsync(System.Reflection.Assembly resourceAssembly, string resourceId);
    }
}
