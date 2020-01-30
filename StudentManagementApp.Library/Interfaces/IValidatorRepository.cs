using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library.Interfaces
{
    public interface IValidatorRepository
    {
        bool IsStudentRegistered(Student student);
    }
}
