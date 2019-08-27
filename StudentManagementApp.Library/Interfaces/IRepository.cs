using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library.Interfaces
{
    public interface IRepository
    {
        bool IsStudentRegistered(Student student);
    }
}
