using System.ComponentModel.DataAnnotations;

namespace SurveyFormProject.Models
{
    public class GuestResponseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Please,enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please enter your phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Please specify whether you will attend.")]
        public bool WillAttend { get; set; }
    }
}
