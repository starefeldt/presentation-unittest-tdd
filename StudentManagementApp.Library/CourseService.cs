using StudentManagementApp.Library.Helpers;
using StudentManagementApp.Library.Models;
using System;
using System.Collections.Generic;

namespace StudentManagementApp.Library
{
    public class CourseService
    {
        private readonly Course _course;
        private List<Enrollment> _enrollments;

        public CourseService(Course course)
        {
            _course = course;
            _enrollments = new List<Enrollment>();
        }

        public void Enroll(Student student)
        {
            var enrollment = new Enrollment
            {
                Student = student,
                Course = _course,
                Created = SystemDateTime.UtcNow(),
            };
            _enrollments.Add(enrollment);
        }

        public List<Enrollment> GetEnrollments()
        {
            return _enrollments;
        }
    }
}
