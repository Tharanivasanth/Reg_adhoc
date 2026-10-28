using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class Reg
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }

                public int Age { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [RegularExpression(@"^[0-9]{10}$",
            ErrorMessage = "Mobile number must contain exactly 10 digits")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

    }
}
