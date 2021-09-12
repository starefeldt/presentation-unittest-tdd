using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library
{
    public interface IStudentRepository
    {
        bool IsStudentRegistered(Student student);
    }
}
