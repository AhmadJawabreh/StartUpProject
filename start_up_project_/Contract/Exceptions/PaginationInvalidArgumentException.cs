using System;

namespace Contract.Exceptions
{

    public class PaginationInvalidArgumentException : Exception
    {
        public PaginationInvalidArgumentException(string title) : base(title)
        {
        }
    }
}
