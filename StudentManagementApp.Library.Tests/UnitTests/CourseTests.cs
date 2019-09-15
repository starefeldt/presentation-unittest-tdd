using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Helpers;
using StudentManagementApp.Library.Models;
using System;
using System.Linq;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class CourseTests
    {
        private static Course GetCourse()
        {
            return new Course();
        }

        [TestCleanup]
        public void Cleanup()
        {
            SystemDateTime.Reset();
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollment()
        {
            //Arrange
            var course = GetCourse();
            var student = new Student();

            //Act
            course.Enroll(student);

            //Assert
            Assert.AreEqual(1, course.GetEnrollments().Count);
        }

        [TestMethod]
        public void GetEnrollments_ByDefault_CanNotAlterEnrollments()
        {
            //Arrange
            var course = GetCourse();
            var student = new Student();

            //Act
            course.Enroll(student);
            var enrollments = course.GetEnrollments();
            enrollments.Add(new Enrollment(student, course, DateTime.Now));

            //Assert
            Assert.AreEqual(1, course.GetEnrollments().Count);
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollmentWithStudentAndCourse()
        {
            //Arrange
            var course = GetCourse();
            var student = new Student();

            //Act
            course.Enroll(student);
            var enrollment = course.GetEnrollments().Single();

            //Assert
            Assert.AreEqual(student, enrollment.Student);
            Assert.AreEqual(course, enrollment.Course);
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollmentWithCreatedDate()
        {
            //Arrange
            var course = GetCourse();
            var student = new Student();

            var expected = DateTime.Now;
            SystemDateTime.Set(expected);

            //Act
            course.Enroll(student);
            var enrollment = course.GetEnrollments().Single();

            //Assert
            Assert.AreEqual(expected, enrollment.Created);
        }

    }
}
