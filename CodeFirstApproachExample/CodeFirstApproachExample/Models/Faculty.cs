namespace CodeFirstApproachExample.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; } = null!;
        public string? HodName { get; set; }

        public List<Student>? FacultyStudents { get; set; }
    }
}
