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
        [TestInitialize]
        public void TestInitialize()
        {
            SystemDateTime.Reset();
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollment()
        {
            //Arrange
            var course = new Course();
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
            var course = new Course();
            var student = new Student();

            //Act
            course.Enroll(student);
            var enrollments = course.GetEnrollments();
            enrollments.Add(new Enrollment(new Student(), new Course(), DateTime.Now));

            //Assert
            Assert.AreEqual(1, course.GetEnrollments().Count);
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollmentWithStudentAndCourse()
        {
            //Arrange
            var course = new Course();
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
            var course = new Course();
            var student = new Student();

            var expectedDate = DateTime.Now;
            SystemDateTime.Set(expectedDate);

            //Act
            course.Enroll(student);
            var enrollment = course.GetEnrollments().Single();

            //Assert
            Assert.AreEqual(expectedDate, enrollment.Created);
        }
    }
}
