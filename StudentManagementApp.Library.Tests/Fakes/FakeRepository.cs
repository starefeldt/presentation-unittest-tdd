using StudentManagementApp.Library.Interfaces;
using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library.Tests.Fakes
{
    public class FakeRepository : IValidatorRepository
    {
        public bool HasRegistered = false;

        public bool IsStudentRegistered(Student student)
        {
            return HasRegistered;
        }
    }
}
