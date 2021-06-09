using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PublisherModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(20, ErrorMessage = "Publisher Name should be less than 20.")]
        [MinLength(10, ErrorMessage = "Publisher Name should be greater than 10.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
     
        public string Phone { get; set; }

        [Required(ErrorMessage = "Street Number is Required")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Street Name is Required")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "City Name is Required")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "State Name is Required")]
        public string StateName { get; set; }

        
        public string Email { get; set; }
    }
}
