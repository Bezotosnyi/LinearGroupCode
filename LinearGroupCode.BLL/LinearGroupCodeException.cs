// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearGroupCodeException.cs" company="DNU">
//   Dima Bezotosnyi
// </copyright>
// <summary>
//   Defines the LinearGroupCodeException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LinearGroupCode.BLL
{
    using System;

    public class LinearGroupCodeException : Exception
    {
        public LinearGroupCodeException()
            : base()
        {
        }

        public LinearGroupCodeException(string message)
            : base(message)
        {
        }
    }
}