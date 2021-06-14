using System;

namespace Contract.Exceptions
{


    public class DubplicatedBookNameException : Exception
    {
        public DubplicatedBookNameException(string title) : base(title)
        {
        }
    }
}
