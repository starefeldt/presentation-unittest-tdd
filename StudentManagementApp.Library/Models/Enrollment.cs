using System;

namespace StudentManagementApp.Library.Models
{
    public class Enrollment
    {
        public Student Student { get; }
        public Course Course { get; }
        public DateTime Created { get; }

        public Enrollment(Student student, Course course, DateTime created)
        {
            Student = student;
            Course = course;
            Created = created;
        }
    }
}
