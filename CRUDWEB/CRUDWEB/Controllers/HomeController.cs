using CRUDWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CRUDWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        // Display form to add a student
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Student());
        }

        // Insert a new student into the database
        [HttpPost]
        public IActionResult Index(Student s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                    {
                        string query = "INSERT INTO STUDENT (Name, Age, Address) VALUES (@Name, @Age, @Address)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Name", s.Name);
                        cmd.Parameters.AddWithValue("@Age", s.Age);
                        cmd.Parameters.AddWithValue("@Address", s.Address);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    return RedirectToAction("Display");
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError("", "An error occurred while registering the student. Please try again.");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Please correct the highlighted errors.");
            }
            return View(s);
        }

        // Display the list of students
        [HttpGet]
        public IActionResult Display()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "SELECT Student_Id, Name, Age, Address FROM STUDENT";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                Student_Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Address = reader.GetString(3)
                            };
                            students.Add(student);
                        }
                    }
                }
                return View(students);
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", "Error fetching students.");
                Console.WriteLine(ex.Message);
                return View(students);
            }
        }

        // Delete a student
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "DELETE FROM STUDENT WHERE Student_Id = @Student_Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Student_Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Display");
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", "An error occurred while deleting the student. Please try again.");
                Console.WriteLine(ex.Message);
                return RedirectToAction("Display");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    // Query to fetch student by id
                    string query = "SELECT Student_Id, Name, Age, Address FROM STUDENT WHERE Student_Id = @Student_Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Student_Id", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mapping the fetched data to the Student object
                            student = new Student
                            {
                                Student_Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Address = reader.GetString(3)
                            };
                        }
                    }
                }
                // Returns the view with student data, passing the student object to the view
                return View(student);
            }
            catch (SqlException ex)
            {
                // Handling any SQL errors
                ModelState.AddModelError("", "Error fetching student details.");
                return View();
            }
        }


        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                    {
                        // Query to update the student record in the database
                        string query = "UPDATE STUDENT SET Name = @Name, Age = @Age, Address = @Address WHERE Student_Id = @Student_Id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Student_Id", s.Student_Id);
                        cmd.Parameters.AddWithValue("@Name", s.Name);
                        cmd.Parameters.AddWithValue("@Age", s.Age);
                        cmd.Parameters.AddWithValue("@Address", s.Address);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    // Redirect to a different action after successful update (e.g., Display)
                    return RedirectToAction("Display");
                }
                catch (SqlException ex)
                {
                    // Handling SQL errors
                    ModelState.AddModelError("", "An error occurred while updating the student. Please try again.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please correct the highlighted errors.");
            }
            // If there's an error, the form is returned with the same student data
            return View(s);
        }

    }
}
