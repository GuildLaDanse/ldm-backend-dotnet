using System;

namespace Auth0.Abstractions
{
    public class CannotCreateClientException : Exception
    {
        public CannotCreateClientException()
        {
        }

        public CannotCreateClientException(string message)
            : base(message)
        {
        }

        public CannotCreateClientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}