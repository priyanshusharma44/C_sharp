using Bca2081MVCEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Bca2081MVCEmpty.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        // Display welcome message
        public IActionResult Hello()
        {
            return View("Index");
        }

        // Retrieve the list of students from the database
        private List<Student> GetStudentList()
        {
            List<Student> list = new List<Student>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("Conn")))
                {
                    string query = "SELECT Id, Name, Address, Fee FROM STUDENT";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Student()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Fee = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", "Error retrieving students from the database.");
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        // Display the student list
        public IActionResult Next()
        {
            return View("Student", GetStudentList());
        }

        // Display a greeting message
        public IActionResult Greeting()
        {
            string msg = "Welcome To My New Page.";
            return View((object)msg);
        }

        // GET: Display the student registration form
        [HttpGet]
        public IActionResult Register()
        {
            return View(new Student());
        }

        // POST: Register a new student
        [HttpPost]
        public IActionResult Register(Student s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("Conn")))
                    {
                        string query = "INSERT INTO STUDENT (Name, Address, Fee) VALUES (@Name, @Address, @Fee)";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.Parameters.AddWithValue("@Name", s.Name);
                        cmd.Parameters.AddWithValue("@Address", s.Address);
                        cmd.Parameters.AddWithValue("@Fee", s.Fee);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    return RedirectToAction("Next");
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

        // GET: Delete a student by id
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("Conn")))
                    {
                        string query = "DELETE FROM STUDENT WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    return RedirectToAction("Next");
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError("", "An error occurred while deleting the student. Please try again.");
                    Console.WriteLine(ex.Message);
                }
            }
            return View();
        }

        // GET: Display the edit form for a student
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student student = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("Conn")))
                {
                    string query = "SELECT Id, Name, Address, Fee FROM STUDENT WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new Student()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Fee = reader.GetDecimal(3)
                            };
                        }
                    }
                }
                if (student != null)
                {
                    return View(student); // Pass student details to view
                }
                else
                {
                    return NotFound(); // Return 404 if not found
                }
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", "Error retrieving student details.");
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Save changes to an existing student
        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("Conn")))
                    {
                        string query = "UPDATE STUDENT SET Name = @Name, Address = @Address, Fee = @Fee WHERE Id = @Id";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.Parameters.AddWithValue("@Id", s.Id);
                        cmd.Parameters.AddWithValue("@Name", s.Name);
                        cmd.Parameters.AddWithValue("@Address", s.Address);
                        cmd.Parameters.AddWithValue("@Fee", s.Fee);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    return RedirectToAction("Next");
                }
                catch (SqlException ex)
                {
                    ModelState.AddModelError("", "An error occurred while updating the student. Please try again.");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Please correct the highlighted errors.");
            }
            return View(s);
        }
    }
}
