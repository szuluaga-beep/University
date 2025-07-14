namespace University.Models
{
    public class CourseAssigment
    {
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; } = null!;

        public Course Course { get; set; } = null!;
    }
}