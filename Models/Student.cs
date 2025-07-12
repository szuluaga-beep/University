using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace universidad.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name ="First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name ="Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Document is required.")]
        public string? Document { get; set; }
    }
}