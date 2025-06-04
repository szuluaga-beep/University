using System;
using System.ComponentModel.DataAnnotations;

namespace University.Models;

public class Course
{

    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public int Credits { get; set; }

}
