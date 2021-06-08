using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MinLength(15, ErrorMessage = "Book Name is Less than 15")]
        [MaxLength(35, ErrorMessage = "Book Name is greater than 35")]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public long? PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public IEnumerable<Author> Authors { get; set; }
    }
}
