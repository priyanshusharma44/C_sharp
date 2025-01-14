using System.ComponentModel.DataAnnotations;

namespace CRUDASPNET.Models
{
    public class Student
     {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
