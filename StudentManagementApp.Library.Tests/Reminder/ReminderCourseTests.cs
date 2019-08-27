using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentManagementApp.Library.Models;
using System;
using System.Linq;

namespace StudentManagementApp.Library.Tests.UnitTests
{
    [TestClass]
    public class ReminderCourseTests
    {
    //    [TestCleanup]
    //    public void TestCleanup()
    //    {
    //        SystemDateTime.Reset();
    //    }

    //    [TestMethod]
    //    public void Enroll_Student_AddsEnrollment()
    //    {
    //        //Arrange
    //        var course = new Course();
    //        var student = new Student();

    //        //Act
    //        course.Enroll(student);

    //        //Assert
    //        Assert.AreEqual(1, course.GetEnrollments().Count);
    //    }

    //    [TestMethod]
    //    public void GetEnrollments_ByDefault_CanNotAlterEnrollments()
    //    {
    //        //Arrange
    //        var course = new Course();
    //        var student = new Student();

    //        //Act
    //        course.Enroll(student);
    //        var enrollments = course.GetEnrollments();
    //        enrollments.Add(new Enrollment(student, course, DateTime.Now));

    //        //Assert
    //        Assert.AreEqual(1, course.GetEnrollments().Count);
    //    }

    //    [TestMethod]
    //    public void Enroll_Student_AddsEnrollmentWithStudentAndCourse()
    //    {
    //        //Arrange
    //        var course = new Course();
    //        var student = new Student();

    //        //Act
    //        course.Enroll(student);
    //        var enrollment = course.GetEnrollments().Single();

    //        //Assert
    //        Assert.AreEqual(student, enrollment.Student);
    //        Assert.AreEqual(course, enrollment.Course);
    //    }

    //    [TestMethod]
    //    public void Enroll_Student_AddsEnrollmentWithCreatedDate()
    //    {
    //        //Arrange
    //        var course = new Course();
    //        var student = new Student();

    //        var date = DateTime.Now;
    //        SystemDateTime.Set(date);

    //        //Act
    //        course.Enroll(student);
    //        var enrollment = course.GetEnrollments().Single();

    //        //Assert
    //        Assert.AreEqual(date, enrollment.Created);
    //    }
    }
}
