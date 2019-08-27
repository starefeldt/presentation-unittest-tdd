using StudentManagementApp.Library.Interfaces;
using StudentManagementApp.Library.Models;
using System.Data.SqlClient;

namespace StudentManagementApp.Library.DataAccess
{
    public class StudentRepository : IRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool IsStudentRegistered(Student student)
        {
            var query = @"SELECT 1
                          FROM Student
                          WHERE SocialSecurityNumber = @socSecNum
                         ";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@socSecNum", student.SocialSecurityNumber);
                    var reader = cmd.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }

    }
}
