using System;

namespace Contract.Exceptions
{

    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string title) : base(title)
        {
        }
    }
}
