using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Models;
using System;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class EnrollmentTests
    {
        [TestMethod]
        public void Ctor_ByDefault_GuardsAgainstNullStudent()
        {
            //Arrange, Act & Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() =>
                new Enrollment(null, new Course(), DateTime.Now));

            StringAssert.Contains(ex.Message, $"{nameof(Student)}");
        }

        [TestMethod]
        public void Ctor_ByDefault_GuardsAgainstNullCourse()
        {
            //Arrange, Act & Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() =>
                new Enrollment(new Student(), null, DateTime.Now));

            StringAssert.Contains(ex.Message, $"{nameof(Course)}");
        }
    }
}
