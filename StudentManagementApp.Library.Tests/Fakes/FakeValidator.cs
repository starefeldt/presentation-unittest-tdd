using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library.Tests.Fakes
{
    public class FakeValidator : IValidator
    {
        public bool IsApproved;

        public bool IsStudentApproved(Student student)
        {
            return IsApproved;
        }
    }
}
