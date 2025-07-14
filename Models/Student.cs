using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "First name")]
        public string FirstMidName { get; set; } = null!;

        [DataType(DataType.Date)]
        [Required]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}