using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, Range(15, 15)]
        public String Name { get; set; }

        [Required, Range(15, 35)]
        public String Address { get; set; }

        [Phone]
        public String Phone { get; set; }


        [EmailAddress]
        public String Email { get; set; }

        public IEnumerable<Book> Books { get; set;}
    }
}
