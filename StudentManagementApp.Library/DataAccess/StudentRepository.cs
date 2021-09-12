using StudentManagementApp.Library.Models;
using System.Data.SqlClient;

namespace StudentManagementApp.Library.DataAccess
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository()
        {
            //Do not hardcode connectionstrings!
            _connectionString = "Data Source=.;Database=GUARANTEED_TO_FAIL;Connection Timeout=1";
        }

        public bool IsStudentRegistered(Student student)
        {
            var query = @"SELECT 1
                          FROM Student
                          WHERE Id = @id
                         ";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", student.Id);
                    var reader = cmd.ExecuteReader();
                    return reader.HasRows;
                }
            }
        }
    }
}
