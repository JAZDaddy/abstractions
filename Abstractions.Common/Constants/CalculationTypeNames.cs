using System;
using System.Collections.Generic;
using System.Text;

namespace Abstractions.Common.Constants
{
    /// <summary>
    /// 
    /// </summary>
    public static class CalculationTypeNames
    {
        /// <summary>
        /// The addition operation on doubles.
        /// </summary>
        public static readonly string Add = "Add";
        /// <summary>
        /// The subtraction operation on doubles.
        /// </summary>
        public static readonly string Subtract = "Subtract";
        /// <summary>
        /// The multiplication operation on doubles.
        /// </summary>
        public static readonly string Multiply = "Multiply";
        /// <summary>
        /// The division operation on doubles.
        /// </summary>
        public static readonly string Divide = "Divide";
        /// <summary>
        /// The exponentiation operation on doubles.
        /// </summary>
        public static readonly string Exponentiation = "Exponentiation";
        #region Advanced
        /// <summary>
        /// The concatenation operation on strings.
        /// </summary>
        public static readonly string Concatenation = "Concatenation";
        #endregion
    }
}
