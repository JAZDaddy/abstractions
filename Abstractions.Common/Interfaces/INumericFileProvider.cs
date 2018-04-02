using System;
using System.Threading.Tasks;

namespace Abstractions.Common.Interfaces
{
    public interface INumericFileProvider
    {
        Task<NumericFile> GetNumericFile();
    }
}
