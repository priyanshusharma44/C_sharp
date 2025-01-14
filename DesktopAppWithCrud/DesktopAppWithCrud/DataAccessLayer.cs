using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DesktopAppWithCrud
{
    public class DataAccessLayer
    {
        const string conString = "your_connection_string_here";
        SqlConnection connection = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public DataAccessLayer()
        {
            connection = new SqlConnection(conString);
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            connection.Open();
            cmd = new SqlCommand("SELECT * FROM STUDENT", connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student s = new Student
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = Convert.ToString(reader["Name"]),
                    Address = Convert.ToString(reader["Address"]),
                    Phone = Convert.ToString(reader["Phone"]),
                    DoB = Convert.ToDateTime(reader["DoB"])
                };
                students.Add(s);
            }
            reader.Close();
            connection.Close();
            return students;
        }

        public bool Register(Student s)
        {
            connection.Open();
            string query = "INSERT INTO STUDENT (Name, Address, Phone, DoB) VALUES (@Name, @Address, @Phone, @DoB)";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Address", s.Address);
            cmd.Parameters.AddWithValue("@Phone", s.Phone);
            cmd.Parameters.AddWithValue("@DoB", s.DoB);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }

        public bool Edit(Student s, int oldId)
        {
            connection.Open();
            string query = "UPDATE STUDENT SET Name = @Name, Address = @Address, Phone = @Phone, DoB = @DoB WHERE Id = @Id";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", oldId);
            cmd.Parameters.AddWithValue("@Name", s.Name);
            cmd.Parameters.AddWithValue("@Address", s.Address);
            cmd.Parameters.AddWithValue("@Phone", s.Phone);
            cmd.Parameters.AddWithValue("@DoB", s.DoB);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }

        public bool Remove(int id)
        {
            connection.Open();
            string query = "DELETE FROM STUDENT WHERE Id = @Id";
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result > 0;
        }
    }
}
