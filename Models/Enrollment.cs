﻿using System.ComponentModel.DataAnnotations;

namespace University.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade assigned")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}