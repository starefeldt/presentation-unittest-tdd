using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Models;
using StudentManagementApp.Library.Tests.Fakes;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class StudentValidatorTests
    {
        [TestMethod]
        public void IsApprovedForCSN_WhenAgeIsOver56_ReturnsFalse()
        {
            //Arrange
            var stubRepo = new FakeRepository();

            var student = new Student();
            student.Age = 57;
            var validator = new StudentValidator(stubRepo, student);

            //Act
            var result = validator.IsApprovedForCSN();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsApprovedForCSN_WhenStudentIsNotRegistered_ReturnsFalse()
        {
            //Arrange
            var stubRepo = new FakeRepository();
            var student = new Student();
            student.Age = 21;
            var validator = new StudentValidator(stubRepo, student);

            //Act
            var result = validator.IsApprovedForCSN();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsApprovedForCSN_WhenStudentIsRegistered_ReturnsTrue()
        {
            //Arrange
            var stubRepo = new FakeRepository();
            stubRepo.HasRegistered = true;

            var student = new Student();
            student.Age = 21;
            var validator = new StudentValidator(stubRepo, student);

            //Act
            var result = validator.IsApprovedForCSN();

            //Assert
            Assert.IsTrue(result);
        }
    }
}
