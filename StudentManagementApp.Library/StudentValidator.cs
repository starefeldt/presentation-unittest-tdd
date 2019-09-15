using StudentManagementApp.Library.DataAccess;
using StudentManagementApp.Library.Interfaces;
using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library
{
    public class StudentValidator
    {
        private readonly Student _student;
        private readonly IRepository _repository;

        public StudentValidator(Student student, IRepository repository)
        {
            _student = student;
            _repository = repository;
        }

        public bool IsApprovedForCSN()
        {
            if (_student.Age > 56)
            {
                return false;
            }

            if (!_repository.IsStudentRegistered(_student))
            {
                return false;
            }

            return true;
        }
    }
}
