using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetmvcapp.Controllers;
using dotnetmvcapp.Models;
using dotnetmvcapp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace dotnetmvcapp.Tests
{
    [TestFixture]
    public class CourseControllerTests
    {
        private CourseController _controller;
        private Mock<ICourseService> _mockCourseService;

        [SetUp]
        public void Setup()
        {
            _mockCourseService = new Mock<ICourseService>();
            _controller = new CourseController(_mockCourseService.Object);
        }
        [Test]
        public void AddCourse_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("AddCourse", new Type[0]) != null,
                Is.True, "AddCourse action does not exist."
            );
        }
        [Test]
        public void CourseIndex_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Index", new Type[0]) != null,
                Is.True, "Index action does not exist."
            );
        }

    [Test]
public void CourseDelete_ActionExists()
{
    // Assert
    Assert.That(
        _controller.GetType().GetMethod("Delete", new[] { typeof(int) }) != null,
        Is.True, "Delete action does not exist."
    );
}
  [Test]
        public async Task AddCourse_ValidCourse_RedirectsToIndex()
        {
            // Arrange
            var mockCourseService = new Mock<ICourseService>();
            mockCourseService.Setup(service => service.AddCourse(It.IsAny<Course>()))
                .ReturnsAsync(true);
            var controller = new CourseController(mockCourseService.Object);

            // Act
            var result = await controller.AddCourse(new Course());

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task AddCourse_InvalidCourse_ReturnsBadRequest()
        {
            // Arrange
            var controller = new CourseController(Mock.Of<ICourseService>());

            // Act
            var result = await controller.AddCourse(null);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }


        [Test]
        public async Task Delete_ValidId_RedirectsToIndex()
        {
            // Arrange
            int courseId = 1;
            _mockCourseService.Setup(service => service.DeleteCourse(courseId))
                .Returns(true);

            // Act
            var result = _controller.Delete(courseId);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Delete_ServiceFails_ReturnsErrorView()
        {
            // Arrange
            int courseId = 1;
            _mockCourseService.Setup(service => service.DeleteCourse(courseId))
                .Returns(false);

            // Act
            var result = _controller.Delete(courseId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("Error"));
        }

        [Test]
        public void Delete_ExceptionThrown_ReturnsErrorView()
        {
            // Arrange
            int courseId = 1;
            _mockCourseService.Setup(service => service.DeleteCourse(courseId))
                .Throws<Exception>();

            // Act
            var result = _controller.Delete(courseId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("Error"));
        }
    }
}
