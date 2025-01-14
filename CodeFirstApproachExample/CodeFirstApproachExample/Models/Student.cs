namespace CodeFirstApproachExample.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;    
        public string StudentAddress { get; set; }
        public string? StudentEmail { get; set;} 

        public decimal AnnualFee { get; set; }

        public int FacultyId { get; set; }
        public Faculty StudentFaculty { get; set; } = null!;
    }
}
