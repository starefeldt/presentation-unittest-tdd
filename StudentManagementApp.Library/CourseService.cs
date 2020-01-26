using StudentManagementApp.Library.Helpers;
using StudentManagementApp.Library.Interfaces;
using StudentManagementApp.Library.Models;
using System.Collections.Generic;

namespace StudentManagementApp.Library
{
    public class CourseService
    {
        private readonly Course _course;
        private readonly IStudentValidator _validator;
        private readonly List<Enrollment> _enrollments;

        public CourseService(Course course, IStudentValidator validator)
        {
            _course = course;
            _validator = validator;
            _enrollments = new List<Enrollment>();
        }

        public void Enroll(Student student)
        {
            if (_validator.IsApprovedForEnrollment())
            {
                var enrollment = new Enrollment(_course, student, SystemDateTime.UtcNow());
                _enrollments.Add(enrollment);
            }
        }

        public List<Enrollment> GetEnrollments()
        {
            return _enrollments;
        }
    }
}
