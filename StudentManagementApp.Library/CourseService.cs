using StudentManagementApp.Library.Helpers;
using StudentManagementApp.Library.Models;
using System.Collections.Generic;

namespace StudentManagementApp.Library
{
    public class CourseService
    {
        private readonly Course _course;
        private readonly IValidator _validator;
        private readonly List<Enrollment> _enrollments;

        public CourseService(Course course, IValidator validator)
        {
            _course = course;
            _validator = validator;
            _enrollments = new List<Enrollment>();
        }

        public void Enroll(Student student)
        {
            var enrollment = new Enrollment(student, _course, SystemDateTime.UtcNow());
            _enrollments.Add(enrollment);
        }

        public List<Enrollment> GetEnrollments()
        {
            return _enrollments;
        }

        public bool Validate(Student student)
        {
            return _validator.IsStudentApproved(student);
        }
    }
}
