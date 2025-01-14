using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
namespace CRUDCONSOLE
{
    public class StudentnNamuna
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class DataAccess
    {
        public string connectionString = "SERVER=localhost; Database=StudentNamuna; Trusted_Connection=True; TrustServerCertificate=True;";


        public void AddStudent(StudentnNamuna s)

        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO StudentNamuna(Id,Name,Address) VALUES(@Id,@Name,@Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", s.Id);
                cmd.Parameters.AddWithValue("@Name", s.Name);
                cmd.Parameters.AddWithValue("@Address", s.Address);
                cmd.ExecuteNonQuery();

            }


        }

        public void GetStudent()

        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM StudentNamuna";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id:{reader["Id"]}, Name:{reader["Name"]},Address:{reader["Address"]}");

                }
               

            }


        }


       
        public void UpdateStudent(int idToUpdate, string NameToUpdate, string AddressToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE StudentNamuna SET Id= @Id, Name= @Name, Address= @Address where Id= @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", idToUpdate);
                cmd.Parameters.AddWithValue("@Name", NameToUpdate);
                cmd.Parameters.AddWithValue("@Address", AddressToUpdate);
                cmd.ExecuteNonQuery();

            }


        }

        public void DeleteStudent(int IdToDelete)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "Delete from StudentNamuna where Id= @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", IdToDelete);

                cmd.ExecuteNonQuery();

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
                Console.WriteLine("*******CRUD*******");
                Console.WriteLine();
                Console.WriteLine("1.Add Student");
                Console.WriteLine();
                Console.WriteLine("2.Show Student");
                Console.WriteLine();
                Console.WriteLine("3.Update Student");
                Console.WriteLine();
                Console.WriteLine("4.Delete Student");
                Console.WriteLine();
                Console.WriteLine("5.Exit");
                Console.WriteLine();
                Console.WriteLine("Select Option:");
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }
                switch (option)
                {


                    case 1:
                        {
                            StudentnNamuna student = new StudentnNamuna();
                            Console.WriteLine("Enter Id");
                            student.Id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Name");
                            student.Name = Console.ReadLine();
                            Console.WriteLine("Enter Address");
                            student.Address = Console.ReadLine();
                            Console.WriteLine();
                            dataAccess.AddStudent(student);
                            Console.WriteLine("Student Added Sucessfully");
                            break;
                        }

                    case 2:
                        {
                            StudentnNamuna student = new StudentnNamuna();
                           
                            Console.WriteLine();
                            Console.WriteLine("******STUDENT LIST********");
                            dataAccess.GetStudent();
                            
                            break;
                        }

                    case 3:
                        {
                            StudentnNamuna student = new StudentnNamuna();
                            Console.WriteLine("Enter Id to update");
                            int idToUpdate = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Name to update");
                            string NameToUpdate = Console.ReadLine();
                            Console.WriteLine("Enter Address to update");
                            string AddressToUpdate = Console.ReadLine(); 
                            Console.WriteLine();
                            dataAccess.UpdateStudent(idToUpdate,NameToUpdate,AddressToUpdate);
                            Console.WriteLine("Student Update Sucessfully");
                            break;

                        }
                    case 4:
                        {
                            StudentnNamuna student = new StudentnNamuna();
                            Console.WriteLine("Enter Id to update");
                            int idToDelete = int.Parse(Console.ReadLine());
                           
                            Console.WriteLine();
                            dataAccess.DeleteStudent(idToDelete);
                            Console.WriteLine("Student Deleted Sucessfully");
                            break;

                        }
                    case 5:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Option! Please select a valid option from the menu.");
                            break;
                        }
                }

            }
        }
    }
}


