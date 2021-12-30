using System;
using System.Collections.Generic;
using System.Text;

namespace MyOnlineShop.Domain.Exceptions
{
    public class OrderTimeNotInRangeException : Exception
    {
        public string StudentName { get; }

        public OrderTimeNotInRangeException() { }

        public OrderTimeNotInRangeException(string message)
            : base(message) { }

        public OrderTimeNotInRangeException(string message, Exception inner)
            : base(message, inner) { }

    }
}
