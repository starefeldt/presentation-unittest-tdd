using StudentManagementApp.Library.Interfaces;
using StudentManagementApp.Library.Models;

namespace StudentManagementApp.Library
{
    public class Validator : IValidator
    {
        private readonly IValidatorRepository _repository;

        public Validator(IValidatorRepository repository)
        {
            _repository = repository;
        }

        public bool IsStudentApproved(Student student)
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
