using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library.Tests.Fakes
{
    public class FakeStudentRepository : IStudentRepository
    {
        public bool HasRegistered;

        public bool IsStudentRegistered(Student student)
        {
            return HasRegistered;
        }
    }
}
