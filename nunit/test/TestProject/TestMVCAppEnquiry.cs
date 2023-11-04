using System;
using System.Reflection;
using System.Threading.Tasks;
using dotnetmvcapp.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using dotnetmvcapp.Models;
using dotnetmvcapp.Services;
namespace dotnetmvcapp.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new HomeController();
        }

       [Test]
        public void Enquiry_Class_Available()
        {
            // Arrange
            Type EnquiryType = typeof(Enquiry);

            // Act & Assert
            Assert.IsNotNull(EnquiryType, "Enquiry class not found.");
        }
        [Test]
        public void Course_Class_Available()
        {
            // Arrange
            Type CourseType = typeof(Course);

            // Act & Assert
            Assert.IsNotNull(CourseType, "Course class not found.");
        }
        [Test]
public void AccountController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Account";
    string controllerNamespace = "dotnetmvcapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}
[Test]
        public void HomeIndex_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Index", new Type[0]) != null,
                Is.True, "Index action does not exist."
            );
        }

[Test]
        public void HomeError_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Error", new Type[0]) != null,
                Is.True, "Error action does not exist."
            );
        }
[Test]
public void HomeController_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc"); // Replace with the actual assembly name

    // Get the namespace and controller name
    string controllerName = "Home";
    string controllerNamespace = "dotnetmvcapp.Controllers"; // Replace with your controller's namespace

    // Construct the full controller type name
    string controllerTypeName = controllerNamespace + "." + controllerName + "Controller";

    // Act
    Type controllerType = assembly.GetType(controllerTypeName);

    // Assert
    Assert.IsNotNull(controllerType, "Controller not found: " + controllerTypeName);
}

[Test]
public void CourseService_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc");
    string className = "dotnetmvcapp.Services.CourseService";
    Type type = assembly.GetType(className);
    Assert.That(type, Is.Not.Null, "CourseService class does not exist in the assembly.");

}

[Test]
public void EnquiryService_Exists()
{
    // Arrange
    var assembly = Assembly.Load("dotnetmvc");
    string className = "dotnetmvcapp.Services.EnquiryService";
    Type type = assembly.GetType(className);
    Assert.That(type, Is.Not.Null, "EnquiryService class does not exist in the assembly.");

}
[TestFixture]
    public class CourseServiceTests
    {
        private Type _courseServiceType;

        [SetUp]
        public void Setup()
        {
            _courseServiceType = typeof(CourseService);
        }

        [Test]
        public void AddCourse_MethodExists()
        {
            Assert.That(_courseServiceType.GetMethod("AddCourse", new[] { typeof(Course) }), Is.Not.Null, "AddCourse method does not exist.");
        }

        [Test]
        public void GetCourseTitles_MethodExists()
        {
            Assert.That(_courseServiceType.GetMethod("GetCourseTitles"), Is.Not.Null, "GetCourseTitles method does not exist.");
        }

        [Test]
        public void GetAllCourses_MethodExists()
        {
            Assert.That(_courseServiceType.GetMethod("GetAllCourses"), Is.Not.Null, "GetAllCourses method does not exist.");
        }

        [Test]
        public void DeleteCourse_MethodExists()
        {
            Assert.That(_courseServiceType.GetMethod("DeleteCourse", new[] { typeof(int) }), Is.Not.Null, "DeleteCourse method does not exist.");
        }
    }
    [TestFixture]
    public class EnquiryServiceTests
    {
        private Type _enquiryServiceType;

        [SetUp]
        public void Setup()
        {
            _enquiryServiceType = typeof(EnquiryService);
        }

        [Test]
        public void AddEnquiry_MethodExists()
        {
            Assert.That(_enquiryServiceType.GetMethod("AddEnquiry", new[] { typeof(Enquiry) }), Is.Not.Null, "AddEnquiry method does not exist.");
        }

        [Test]
        public void GetEnquiryByUserId_MethodExists()
        {
            Assert.That(_enquiryServiceType.GetMethod("GetEnquiryByUserId", new[] { typeof(string) }), Is.Not.Null, "GetEnquiryByUserId method does not exist.");
        }

        [Test]
        public void GetAllEnquirys_MethodExists()
        {
            Assert.That(_enquiryServiceType.GetMethod("GetAllEnquirys"), Is.Not.Null, "GetAllEnquirys method does not exist.");
        }

        [Test]
        public void DeleteEnquiry_MethodExists()
        {
            Assert.That(_enquiryServiceType.GetMethod("DeleteEnquiry", new[] { typeof(int) }), Is.Not.Null, "DeleteEnquiry method does not exist.");
        }
    }
    }
}
