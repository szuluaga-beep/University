using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        [Display(Name = "Hire date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Display(Name = "Full name")]
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }

        public ICollection<CourseAssigment> CourseAssignments { get; set; } = new List<CourseAssigment>();
        public OfficeAssignment OfficeAssignment { get; set; } = null!;
    }
}