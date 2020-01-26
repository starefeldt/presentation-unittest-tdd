using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Models;
using StudentManagementApp.Library.Tests.Fakes;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class StudentValidatorTests
    {
        [TestMethod]
        public void IsApprovedForEnrollment_WhenAgeIsUnder18_ReturnsFalse()
        {
            //Arrange
            var student = new Student();
            student.Age = 17;
            var validator = new StudentValidator(student, null);

            //Act
            var result = validator.IsApprovedForEnrollment();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsApprovedForEnrollment_WhenStudentIsNotRegistered_ReturnsFalse()
        {
            //Arrange
            var student = new Student();
            student.Age = 18;
            var stubRepo = new FakeRepository();
            var validator = new StudentValidator(student, stubRepo);

            //Act
            var result = validator.IsApprovedForEnrollment();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsApprovedForEnrollment_WhenStudentIsRegistered_ReturnsTrue()
        {
            //Arrange
            var student = new Student();
            student.Age = 100;
            var stubRepo = new FakeRepository();
            stubRepo.HasRegistered = true;
            var validator = new StudentValidator(student, stubRepo);

            //Act
            var result = validator.IsApprovedForEnrollment();

            //Assert
            Assert.IsTrue(result);
        }
    }
}
