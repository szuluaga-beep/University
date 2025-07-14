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

                var instructors = new Instructor[]
                {
                    new Instructor { FirstName = "Kim", LastName = "Abercrombie", HireDate = DateTime.Parse("1995-03-11") },
                    new Instructor { FirstName = "Fadi", LastName = "Fakhouri", HireDate = DateTime.Parse("2002-07-06") },
                };

                foreach (Instructor i in instructors)
                {
                    context.Instructors.Add(i);
                }
                context.SaveChanges();

                var departments = new Department[]
                {
                    new Department { Name = "English", Budget = 350000, StartDate = DateTime.Parse("2007-09-01"), InstructorID = instructors.Single(i => i.LastName == "Abercrombie").Id },
                    new Department { Name = "Economics", Budget = 100000, StartDate = DateTime.Parse("2007-09-01"), InstructorID = instructors.Single(i => i.LastName == "Fakhouri").Id }
                };

                foreach (Department de in departments)
                {
                    context.Departments.Add(de);
                }

                context.SaveChanges();

                var officeAssignments = new OfficeAssignment[]
                {
                    new OfficeAssignment {
                        InstructorId = instructors.Single( i => i.LastName == "Fakhouri").Id,
                        Location = "Smith 17" },
                    new OfficeAssignment {
                        InstructorId = instructors.Single( i => i.LastName == "Abercrombie").Id,
                        Location = "Gowan 27" },
                };

                foreach (OfficeAssignment o in officeAssignments)
                {
                    context.OfficeAssignments.Add(o);
                }
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3, DepartmentID= departments.Single(s=>s.Name=="English").DepartmentId },
                    new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3, DepartmentID = departments.Single(d => d.Name == "Economics").DepartmentId },
                   new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3, DepartmentID = departments.Single(d => d.Name == "Economics").DepartmentId },
                   new Course { CourseID = 1045, Title = "Calculus", Credits = 4, DepartmentID = departments.Single(d => d.Name == "English").DepartmentId },
                   new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4, DepartmentID = departments.Single(d => d.Name == "English").DepartmentId },
                   new Course { CourseID = 2021, Title = "Composition", Credits = 3, DepartmentID = departments.Single(d => d.Name == "English").DepartmentId },
                   new Course { CourseID = 2042, Title = "Literature", Credits = 4, DepartmentID = departments.Single(d => d.Name == "English").DepartmentId }
                };

                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }

                context.SaveChanges();

                var courseInstructors = new CourseAssigment[]
                {
                    new CourseAssigment { CourseID = 1050, InstructorID = instructors.Single(i => i.LastName == "Abercrombie").Id },
                    new CourseAssigment { CourseID = 4022, InstructorID = instructors.Single(i => i.LastName == "Fakhouri").Id },
                    new CourseAssigment { CourseID = 4041, InstructorID = instructors.Single(i => i.LastName == "Fakhouri").Id },
                    new CourseAssigment { CourseID = 1045, InstructorID = instructors.Single(i => i.LastName == "Abercrombie").Id },
                    new CourseAssigment { CourseID = 3141, InstructorID = instructors.Single(i => i.LastName == "Abercrombie").Id },
                    new CourseAssigment { CourseID = 2021, InstructorID = instructors.Single(i => i.LastName == "Abercrombie").Id },
                    new CourseAssigment { CourseID = 2042, InstructorID = instructors.Single(i => i.LastName == "Fakhouri").Id }
                };

                foreach (CourseAssigment ca in courseInstructors)
                {
                    context.CourseAssignments.Add(ca);
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