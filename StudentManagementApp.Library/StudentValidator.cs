using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library
{
    public class StudentValidator
    {
        private readonly IStudentRepository _repository;

        public StudentValidator(IStudentRepository repository)
        {
            _repository = repository;
        }

        public bool Validate(Student student)
        {
            if (student.Age < 18)
            {
                return false;
            }

            if (!_repository.IsStudentRegistered(student))
            {
                return false;
            }

            return true;
        }

    }
}
