using StudentManagementApp.Library.Interfaces;

namespace StudentManagementApp.Library.Tests.Fakes
{
    public class FakeValidator : IStudentValidator
    {
        public bool IsApprovedShouldReturn;

        public bool IsApproved()
        {
            return IsApprovedShouldReturn;
        }
    }
}
