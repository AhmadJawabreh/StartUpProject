using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, Range(15, 25)]
        public string Name { get; set; }

        [EmailAddress, Range(15, 30)]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
