using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Common.Interfaces
{
    /// <summary>
    /// A named implementation of IPairwiseFileProvider for doubles.
    /// </summary>
    public interface IPairwiseNumericFileProvider: IPairwiseFileProvider<double>
    {
    }
}
