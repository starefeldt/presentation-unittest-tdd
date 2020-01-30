using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Helpers;
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
        public void Cleanup()
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
            Assert.AreEqual(1, service.GetEnrollments().Count);
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
            Assert.AreEqual(student, enrollment.Student);
            Assert.AreEqual(course, enrollment.Course);
        }

        [TestMethod]
        public void Enroll_Student_AddsEnrollmentWithCreatedDate()
        {
            //Arrange
            var course = new Course();
            var service = GetCourseService(course);
            var student = new Student();

            var expectedCreated = DateTime.UtcNow;
            SystemDateTime.Set(expectedCreated);

            //Act
            service.Enroll(student);

            //Assert
            var enrollment = service.GetEnrollments().Single();
            Assert.AreEqual(expectedCreated, enrollment.Created);
        }

        [TestMethod]
        public void Validate_WhenStudentIsApproved_ReturnsTrue()
        {
            //Arrange
            var course = new Course();
            var stubValidator = new FakeValidator { IsApproved = true };
            var service = GetCourseService(course, stubValidator);
            var student = new Student();

            //Act
            bool result = service.Validate(student);

            //Assert
            Assert.IsTrue(result);
        }

        private CourseService GetCourseService(Course course, IValidator validator = null)
        {
            if (validator == null)
            {
                validator = new FakeValidator();
            }
            return new CourseService(course, validator);
        }
    }
}
