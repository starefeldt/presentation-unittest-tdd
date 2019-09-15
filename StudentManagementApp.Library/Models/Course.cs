using StudentManagementApp.Library.Helpers;
using System;
using System.Collections.Generic;

namespace StudentManagementApp.Library.Models
{
    public class Course
    {
        private readonly List<Enrollment> _enrollments;

        public Course()
        {
            _enrollments = new List<Enrollment>();
        }

        public void Enroll(Student student)
        {
            var enrollment = new Enrollment(student, this, SystemDateTime.Now());
            _enrollments.Add(enrollment);
        }

        public List<Enrollment> GetEnrollments()
        {
            return new List<Enrollment>(_enrollments);
        }
    }
}
