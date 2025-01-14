using System.ComponentModel.DataAnnotations;

namespace Bca2081MVCEmpty.Models
{

    //we do validation here

    //default file name will get same as className 
    //so lets leave it as default
    public class Student
    {
        //we normally use shorthand notation 
        public int Id { get; set; }
        [Required(ErrorMessage ="You Must Supply Name.")]
        //so from here we can set things dynamically ..like name..it will take as asp-for
        [Display(Name="Student's Name")]
        [MinLength(6,ErrorMessage ="Lenght must be above 6")]
        //null! is after .net 5 ...here we need to make first nullable after version 5 
        public string Name { get; set; } = null!;
        //to make in pw word
       // [DataType(DataType.Password)]
        public string? Address { get; set; }
        [Required(ErrorMessage ="You Must supply fee.")]
        [Range(0, 10000, ErrorMessage = "Fee must be between 0 and 10,000.")]
        public decimal Fee { get; set; }

    }
}
