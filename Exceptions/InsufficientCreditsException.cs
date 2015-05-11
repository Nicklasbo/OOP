using System;

namespace OOP
{
    class InsufficientCreditsException : Exception
    {

        public InsufficientCreditsException()
        {
        }

        public InsufficientCreditsException(string message)
            : base(message)
        {
        }

        public InsufficientCreditsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
