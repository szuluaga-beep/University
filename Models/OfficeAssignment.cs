using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorId { get; set; }

        [Display(Name = "Office location")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Location { get; set; } = null!;

        public Instructor Instructor { get; set; } = null!;
    }
}