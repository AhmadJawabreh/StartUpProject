using System;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class PublisherModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="First Name is Required")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Street Number is Required")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Street Name is Required")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "City Name is Required")]
        public string CityName { get; set;  }

        [Required(ErrorMessage = "State Name is Required")]
        public string StateName { get; set;  }

        [Required(ErrorMessage = "Address Is Required")]
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
