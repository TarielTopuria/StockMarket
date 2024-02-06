namespace api.Handlers.CustomExceptions
{
    using System;

    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public NotFoundException(string message, int entityId) : base($"{message}: Entity ID {entityId}") { }
    }

}
