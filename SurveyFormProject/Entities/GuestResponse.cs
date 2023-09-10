using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SurveyFormProject.Entities
{
    [Table("GuestResponses")]
    public class GuestResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }       
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public bool WillAttend { get; set; }


    }
}
