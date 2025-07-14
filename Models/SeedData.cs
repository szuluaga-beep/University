using Microsoft.EntityFrameworkCore;
using University.Data;

namespace University.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversityContext(
                serviceProvider.GetRequiredService<DbContextOptions<UniversityContext>>()
                ))
            {
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }
                var students = new Student[]
                {
                new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01") },
                new Student { FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01") },
                new Student { FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01") },
                new Student { FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01") }
                };
                foreach (Student s in students)
                {
                    context.Students.Add(s);
                }
                context.SaveChanges();

                var courses = new Course[]
                {
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 },
                new Course { CourseID = 1045, Title = "Calculus", Credits = 4 },
                new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4 },
                new Course { CourseID = 2021, Title = "Composition", Credits = 3 },
                new Course { CourseID = 2042, Title = "Literature", Credits = 4 }
                };

                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }

                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                new Enrollment { StudentID = students.Single(s => s.LastName == "Alexander").ID, CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID, Grade = Grade.A },
                new Enrollment { StudentID = students.Single(s => s.LastName == "Alonso").ID, CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID, Grade = Grade.C },
                new Enrollment { StudentID = students.Single(s => s.LastName == "Anand").ID, CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID, Grade = Grade.B },
                new Enrollment { StudentID = students.Single(s => s.LastName == "Barzdukas").ID, CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID, Grade = Grade.B },
                new Enrollment { StudentID = students.Single(s => s.LastName == "Li").ID, CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID, Grade = Grade.B },
                new Enrollment { StudentID = students.Single(s => s.LastName == "Justice").ID, CourseID = courses.Single(c => c.Title == "Composition" ).CourseID, Grade = Grade.B },
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}