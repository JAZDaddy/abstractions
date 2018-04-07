using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Common.Interfaces
{
    /// <summary>
    /// Describes a class which provides a read-only Description property
    /// </summary>
    public interface IDescribable
    {
        /// <summary>
        /// The description of the object.
        /// </summary>
        string Description { get; }
    }
}
