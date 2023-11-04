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
    public class EnquiryControllerTests
    {
        private EnquiryController _controller;
        private Mock<IEnquiryService> _mockEnquiryService;

        [SetUp]
        public void Setup()
        {
            _mockEnquiryService = new Mock<IEnquiryService>();
            _controller = new EnquiryController(_mockEnquiryService.Object);
        }

        [Test]
        public void AddEnquiry_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("AddEnquiry", new Type[0]) != null,
                Is.True, "AddEnquiry action does not exist."
            );
        }

        [Test]
        public void EnquiryIndex_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Index", new Type[0]) != null,
                Is.True, "Index action does not exist."
            );
        }

        [Test]
        public void UserEnquiry_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("UserEnquiry", new Type[0]) != null,
                Is.True, "UserEnquiry action does not exist."
            );
        }

        [Test]
        public void EnquiryDelete_ActionExists()
        {
            // Assert
            Assert.That(
                _controller.GetType().GetMethod("Delete", new[] { typeof(int) }) != null,
                Is.True, "Delete action does not exist."
            );
        }


        [Test]
        public async Task Delete_ValidId_RedirectsToIndex()
        {
            // Arrange
            int enquiryId = 1;
            _mockEnquiryService.Setup(service => service.DeleteEnquiry(enquiryId))
                .Returns(true);

            // Act
            var result = _controller.Delete(enquiryId);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = (RedirectToActionResult)result;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Delete_ServiceFails_ReturnsErrorView()
        {
            // Arrange
            int enquiryId = 1;
            _mockEnquiryService.Setup(service => service.DeleteEnquiry(enquiryId))
                .Returns(false);

            // Act
            var result = _controller.Delete(enquiryId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("Error"));
        }

        [Test]
        public void Delete_ExceptionThrown_ReturnsErrorView()
        {
            // Arrange
            int enquiryId = 1;
            _mockEnquiryService.Setup(service => service.DeleteEnquiry(enquiryId))
                .Throws<Exception>();

            // Act
            var result = _controller.Delete(enquiryId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("Error"));
        }
    }
}
