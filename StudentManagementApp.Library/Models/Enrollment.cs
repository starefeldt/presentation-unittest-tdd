using System;

namespace StudentManagementApp.Library.Models
{
    public class Enrollment
    {
        public Enrollment(Course course, Student student, DateTime created)
        {
            Course = course ?? throw new ArgumentNullException(nameof(Course));
            Student = student ?? throw new ArgumentNullException(nameof(Student));
            Created = created;
        }

        public Course Course { get; }
        public Student Student { get; }
        public DateTime Created { get; }
    }
}
