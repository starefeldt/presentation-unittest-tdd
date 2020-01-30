using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library
{
    public interface IValidator
    {
        bool IsStudentApproved(Student student);
    }
}