using System.ComponentModel.DataAnnotations;

namespace CRUDWEB.Models
{
    public class Student
    {
        public int Student_Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 120, ErrorMessage = "Please enter a valid age.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
