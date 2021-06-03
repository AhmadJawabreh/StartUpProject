using System;
using System.Collections.Generic;

namespace Entities
{
    public class Book
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public long PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public IEnumerable<AutherBook> Authers { get; set; }

    }
}
