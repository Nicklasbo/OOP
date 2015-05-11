using System;

namespace OOP
{
    class ValidationException : Exception
    {
        public ValidationException()
            : base()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
