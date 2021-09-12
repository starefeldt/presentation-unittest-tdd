using System;

namespace StudentManagementApp.Library.Models
{
    public class Enrollment
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime Created { get; set; }
    }
}
