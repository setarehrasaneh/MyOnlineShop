using System;
using System.Runtime.Serialization;

namespace MyOnlineShop.Domain.Exceptions
{
    [Serializable]
    internal class CheckPriceRangeException : Exception
    {
        public CheckPriceRangeException()
        {
        }

        public CheckPriceRangeException(string message) : base(message)
        {
        }

        public CheckPriceRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}