using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Models;
using StudentManagementApp.Library.Tests.Fakes;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class StudentValidatorTests
    {
        [TestMethod]
        public void Validate_WhenAgeIsUnder18_ReturnsFalse()
        {
            //Arrange
            var validator = new StudentValidator(null);
            var student = new Student();
            student.Age = 17;

            //Act
            var result = validator.Validate(student);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_WhenStudentIsNotRegistered_ReturnsFalse()
        {
            //Arrange
            var fakeRepo = new FakeStudentRepository();
            fakeRepo.HasRegistered = false;

            var validator = new StudentValidator(fakeRepo);
            var student = new Student();
            student.Age = 20;

            //Act
            var result = validator.Validate(student);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_WhenStudentIsValid_ReturnsTrue()
        {
            //Arrange
            var fakeRepo = new FakeStudentRepository();
            fakeRepo.HasRegistered = true;

            var validator = new StudentValidator(fakeRepo);
            var student = new Student();
            student.Age = 20;

            //Act
            var result = validator.Validate(student);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
