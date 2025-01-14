using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingRestfulApi.Models;

namespace TestingRestfulApi.Controllers
{
    [Route("api/[controller]")] //www.abc.com/api/Student
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentDbContext context;
        public StudentController(StudentDbContext _context) 
        {
            context = _context;
        }
        [HttpGet]
        public List<Student> GetStudentList()
        {
            return context.Students.ToList();
        }
        [HttpPost]
/*        public Student AddStudent(Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
            return s;
        }*/
         public ActionResult<Student> AddStudent(Student s)
        {
            context.Students.Add(s);
            context.SaveChanges();
            return Ok(s);
        }

        // Get details of a student by ID
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();  // Return 404 if student not found
            }
            return Ok(student);  // Return the student if found
        }

        [HttpPut]
        public ActionResult<Student> EditStudent(Student s)
        {
            context.Students.Update(s);
            context.SaveChanges();
            return Ok(s);
        }
        [HttpPut("{id}")]
        public ActionResult<Student> EditStudent(int id, Student updateStudent)
        {
            var student= context.Students.FirstOrDefault(s=>s.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            student.Name = updateStudent.Name;
            student.Address = updateStudent.Address;
            student.Fee = updateStudent.Fee;
            context.Students.Update(student);
            context.SaveChanges();
          return Ok(student);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public ActionResult DeleteStudent(int id)
        {
            Student? s = context.Students.Where(s => s.Id == id).FirstOrDefault();
            if(s== null)
                return NotFound();
            else
            {
                context.Students.Remove(s);
                context.SaveChanges();
                return Ok(s);
            }
        }
    }
}
