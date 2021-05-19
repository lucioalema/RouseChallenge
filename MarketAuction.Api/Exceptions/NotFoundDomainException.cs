using System;
namespace MarketAuction.Api.Exceptions
{
    public class NotFoundDomainException : DomainException
    {
        public NotFoundDomainException() { }

        public NotFoundDomainException(string message) : base(message) { }

        public NotFoundDomainException(string message, Exception exception) : base(message, exception) { }
    }
}
