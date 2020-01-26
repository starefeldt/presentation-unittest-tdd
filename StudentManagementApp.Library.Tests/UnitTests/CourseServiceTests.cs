using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Helpers;
using StudentManagementApp.Library.Interfaces;
using StudentManagementApp.Library.Models;
using StudentManagementApp.Library.Tests.Fakes;
using System;
using System.Linq;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class CourseServiceTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            SystemDateTime.Reset();
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollment()
        {
            //Arrange
            var course = new Course();
            var service = GetCourseService(course);
            var student = new Student();

            //Act
            service.Enroll(student);

            //Assert
            Assert.AreEqual(1, service.GetEnrollments().Count());
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollmentWithStudentAndCourse()
        {
            //Arrange
            var course = new Course();
            var service = GetCourseService(course);
            var student = new Student();

            //Act
            service.Enroll(student);

            //Assert
            var enrollment = service.GetEnrollments().Single();
            Assert.AreEqual(course, enrollment.Course);
            Assert.AreEqual(student, enrollment.Student);
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollmentWithCreatedDate()
        {
            //Arrange
            var course = new Course();
            var service = GetCourseService(course);
            var student = new Student();

            var expected = DateTime.UtcNow;
            SystemDateTime.Set(expected);

            //Act
            service.Enroll(student);

            //Assert
            var enrollment = service.GetEnrollments().Single();
            Assert.AreEqual(expected, enrollment.Created);
        }

        [TestMethod]
        public void Enroll_WhenNotApprovedForEnrollment_DoesNotAddEnrollment()
        {
            //Arrange
            var course = new Course();
            var validator = new FakeValidator() { IsApproved = false };
            var service = GetCourseService(course, validator);
            var student = new Student();

            //Act
            service.Enroll(student);

            //Assert
            Assert.AreEqual(0, service.GetEnrollments().Count());
        }
        
        private static CourseService GetCourseService(
            Course course, 
            FakeValidator validator = null)
        {
            if(validator == null)
            {
                validator = new FakeValidator { IsApproved = true };
            }

            return new CourseService(course, validator);
        }
    }
}
