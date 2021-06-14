using System;

namespace Contract.Exceptions
{
    public class PublisherContactException : Exception
    {
        public PublisherContactException(string title) : base(title)
        {
        }
    }
}
