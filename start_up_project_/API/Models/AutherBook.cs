namespace Entities
{
    public class AutherBook
    {
        public long AutherId { get; set; }
        public Auther Auther { get; set; }

        public long BookId {get; set;}
        public Book Book { get; set; }


    }
}
