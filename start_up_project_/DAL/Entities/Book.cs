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

        [Required, Range(15, 35)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public long PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public IEnumerable<Author> Authors { get; set; }

    }
}
