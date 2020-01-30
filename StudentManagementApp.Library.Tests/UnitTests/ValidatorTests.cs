using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Models;
using StudentManagementApp.Library.Tests.Fakes;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void IsStudentApproved_WhenAgeIsUnder18_ReturnsFalse()
        {
            //Arrange
            var validator = new Validator(null);
            var student = new Student { Age = 17 };

            //Act
            var result = validator.IsStudentApproved(student);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStudentApproved_WhenNotRegistered_ReturnsFalse()
        {
            //Arrange
            var stubRepo = new FakeRepository();
            var validator = new Validator(stubRepo);
            var student = new Student { Age = 20 };

            //Act
            var result = validator.IsStudentApproved(student);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStudentApproved_WhenRegistered_ReturnsTrue()
        {
            //Arrange
            var stubRepo = new FakeRepository { HasRegistered = true };
            var validator = new Validator(stubRepo);
            var student = new Student { Age = 20 };

            //Act
            var result = validator.IsStudentApproved(student);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
