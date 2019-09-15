using StudentManagementApp.Library.Interfaces;
using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library.Tests.Fakes
{
    public class FakeRepository : IRepository
    {
        public bool HasRegistered;

        public bool IsStudentRegistered(Student student)
        {
            return HasRegistered;
        }
    }
}
