using System;
using System.ComponentModel.DataAnnotations;

namespace University.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    public required string FullName { get; set; }

    [Required]
    public required int Document { get; set; }

    [EmailAddress]
    public required string Email { get; set; }
}
