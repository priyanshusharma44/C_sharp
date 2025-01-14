using AppointmentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AppointmentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        // Constructor injection for IConfiguration to get the connection string
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Index action to show the login page
        public IActionResult Index()
        {
            return View();
        }

        // Action to handle user login (POST)
        [HttpPost]
        public IActionResult Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser = ValidateUserLogin(model);

                if (isValidUser)
                {
                    // Redirect to the dashboard on successful login
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    // Add error message if login fails
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }

            // Return to the login page if validation fails
            return View("Index");
        }

        // Action for the dashboard
        public IActionResult Dashboard()
        {
            return View(); // Return the dashboard view
        }

        // Method to validate the user login from the database
        private bool ValidateUserLogin(UserLogin model)
        {
            bool isValid = false;

            // Get the connection string from the configuration
            string connectionString = _configuration.GetConnectionString("Conn");

            // SQL query to validate user
            string query = "SELECT COUNT(1) FROM dbo.UserLogin WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword";

            // Establish SQL connection and execute the query
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserEmail", model.UserEmail);
                cmd.Parameters.AddWithValue("@UserPassword", model.UserPassword); // Password should ideally be hashed

                conn.Open();
                int userCount = (int)cmd.ExecuteScalar(); // Executes the query and returns the count of matching rows

                if (userCount > 0)
                {
                    isValid = true;  // User is valid
                }
            }

            return isValid;
        }
    }
}
