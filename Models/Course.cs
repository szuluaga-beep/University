using System.ComponentModel.DataAnnotations;

namespace universidad.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        public int Code { get; set; }

        [Required(ErrorMessage = "Credits are required.")]
        public int Credits { get; set; }
    }
}