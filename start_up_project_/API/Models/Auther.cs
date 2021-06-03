using System;
using System.Collections.Generic;
namespace Entities { 
    public class Auther
    {
        public long Id { get; set; }

        public string Name{ get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public IEnumerable<AutherBook> Books { get; set; }
    }
}
