
using System;
using System.Collections.Generic;
using System.Linq;
using AadhaarVerification.Controllers;
using AadhaarVerification.Models;
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

namespace NUnitTesting
{
    [TestFixture]
    public class UserDataControllerTests
    {
        
        [Test]
        public void GetData_ReturnsOkResult()
        {
            // Arrange
            var controller = new UserDataController();

            // Act
            var result = controller.GetData();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.IsNotNull(okResult.Value);
        }

        [Test]
        public void GetData_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var controller = new UserDataController();
            var testData = new Data { id = 1, FirstName = "John", LastName = "Doe", Age = 25, Address = "123 Main St", Phone = "1234567890", Aadhar = "123456789012", Email = "john.doe@example.com", DocumnetPath = "/documents" };
            controller.CreateData(testData);

            // Act
            var result = controller.GetData(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void CreateData_WithValidData_ReturnsOkResult()
        {
            // Arrange
            var controller = new UserDataController();
            var testData = new Data { FirstName = "John", LastName = "Doe", Age = 25, Address = "123 Main St", Phone = "1234567890", Aadhar = "123456789012", Email = "john.doe@example.com", DocumnetPath = "/documents" };

            // Act
            var result = controller.CreateData(testData);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
 }
}

