using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Helpers;
using StudentManagementApp.Library.Models;
using System;
using System.Linq;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class CourseServiceTests
    {
        [TestCleanup]
        public void TestCleanUp()
        {
            SystemDateTime.Reset();
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollment()
        {
            //Arrange
            var course = new Course();
            var service = new CourseService(course);
            var student = new Student();

            //Act
            service.Enroll(student);

            //Assert
            Assert.AreEqual(1, service.GetEnrollments().Count);
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollmentWithStudentAndCourse()
        {
            //Arrange
            var course = new Course();
            var service = new CourseService(course);
            var student = new Student();

            //Act
            service.Enroll(student);

            //Assert
            var enrollment = service.GetEnrollments().Single();
            Assert.AreEqual(student, enrollment.Student);
            Assert.AreEqual(course, enrollment.Course);
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollmentWithCreatedDate()
        {
            //Arrange
            var course = new Course();
            var service = new CourseService(course);
            var student = new Student();
            var expectedDate = DateTime.UtcNow;
            SystemDateTime.Set(expectedDate);

            //Act
            service.Enroll(student);

            //Assert
            var enrollment = service.GetEnrollments().Single();
            Assert.AreEqual(expectedDate, enrollment.Created);
        }
    }
}
