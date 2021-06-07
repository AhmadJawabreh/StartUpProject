using System;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class AuthorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name is Required"), Range(3, 10)]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last Name is Required"), Range(3, 10)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set;  }
    }
}
