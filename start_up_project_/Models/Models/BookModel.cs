using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release Date is Required")]
        public DateTime ReleaseDate { get; set; }

    }
}
