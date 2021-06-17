using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AuthorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(12, ErrorMessage = "First Name Is greater than 20")]
        [MinLength(8, ErrorMessage = "First Name Is Less than 8")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
