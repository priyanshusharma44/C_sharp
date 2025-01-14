using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
using System.Net;

namespace SelfPractConsoleCRUD
{
    //1.first create model where we can use while adding anything inside the table columns
    public class Student2
    {
        public int Student_Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; }

    }
    //2. DataAccess in order to create connection with database 

    public class DataAccess
    {
        public string connectionString = "Data Source=localhost; Initial Catalog=Student2; Integrated Security=True;TrustServerCertificate=True;";

        //now lets add new student
        public void AddStudent(Student2 student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //open conneciton
                connection.Open();
                //insert query
                string query = "INSERT INTO Student (Name,Age,Address) VALUES (@Name,@Age,@Address)";
                //add query and connection to command
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Clear();
                //add values to the name, age and address
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.ExecuteNonQuery();
            }
        }
        public void getStudent()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM STUDENT"; //query to select 
                //add query and connection to command
                SqlCommand command = new SqlCommand(query, connection); //prepare command
                                                                        //withquery 
                SqlDataReader reader = command.ExecuteReader(); //finally execute query 

                //now the reader has all data ..so read all till end
                while (reader.Read())
                {
                    Console.WriteLine($"ID:{reader["Student_Id"]},Name:{reader["Name"]},Age:{ reader["Age"]},Address:{reader["Address"]}");
                }

            }
        }
        
        public void UpdateStudent(int id, string name, int age, string address)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Student SET Name=@Name, Age=@Age, Address=@Address WHERE Student_Id=@Student_Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Student_Id",id);
                command.Parameters.AddWithValue("@Name",name);
                command.Parameters.AddWithValue("@Age",age);
                command.Parameters.AddWithValue("@Address",address);
                command.ExecuteNonQuery();
                
            }
        }
        public void DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM STUDENT where Student_id=@Student_Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Student_Id", id);

                command.ExecuteNonQuery();
            }


        }
        
        
    }
    public class Program
    {
        static void Main(string[] args)
        {
          DataAccess dataAccess = new DataAccess();


            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write(" Choose a option:");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        //Add Student 
                        Student2 student = new Student2();
                        Console.WriteLine("Enter Name:");
                        student.Name = Console.ReadLine();
                        Console.WriteLine("Enter Age:");
                        student.Age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Address");
                        student.Address = Console.ReadLine();
                        dataAccess.AddStudent(student);
                        Console.WriteLine("Student added successfully.");
                        break;

                        case 2:
                        //View AllStudent
                        Console.WriteLine("List Of Student ");
                        dataAccess.getStudent();
                        break;

                        case 3:
                        //update
                        Console.WriteLine("Enter Id To Update:");
                        int idToUpdate = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Age:");
                         int age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Address");
                         string address = Console.ReadLine();
                        dataAccess.UpdateStudent(idToUpdate, name, age, address);
                        Console.WriteLine("Student updated successfully.");
                        break;

                        case 4:
                        //delete
                        Console.WriteLine("Enter Id to Delete");
                        int idToDelete = int.Parse(Console.ReadLine());
                        dataAccess.DeleteStudent(idToDelete);
                        Console.WriteLine("Deleted Sucessfully");
                        break;
                }


            }

        }
    }
}
