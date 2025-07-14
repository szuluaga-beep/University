using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using University.Models;

namespace University.Data
{
    public class UniversityContext(DbContextOptions<UniversityContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; } = default!;

        public DbSet<Enrollment> Enrollments { get; set; } = default!;
        public DbSet<Student> Students { get; set; } = default!;

        public DbSet<Department> Departments { get; set; } = default!;

        public DbSet<Instructor> Instructors { get; set; } = default!;

        public DbSet<OfficeAssignment> OfficeAssignments { get; set; } = default!;
        public DbSet<CourseAssigment> CourseAssignments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssigment>().ToTable("CourseAssignment");

            modelBuilder.Entity<CourseAssigment>()
                .HasKey(ca => new { ca.CourseID, ca.InstructorID });
        }
    }
}