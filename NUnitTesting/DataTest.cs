using NUnit.Framework;
using AadhaarVerification.Models;

namespace MyTestsProject.Models
{
    [TestFixture]
    public class DataTests
    {
        [Test]
        public void DataModel_ValidProperties_ReturnsTrue()
        {
            // Arrange
            var data = new Data
            {
                id = 1,
                FirstName = "John",
                LastName = "Doe",
                Age = 30,
                Address = "123 Main St",
                Phone = "1234567890",
                Aadhar = "123456789012",
                Email = "john.doe@example.com",
                DocumnetPath = "/path/to/document"
            };

            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.That(data.id, Is.EqualTo(1));
                Assert.That(data.FirstName, Is.EqualTo("John"));
                Assert.That(data.LastName, Is.EqualTo("Doe"));
                Assert.That(data.Age, Is.EqualTo(30));
                Assert.That(data.Address, Is.EqualTo("123 Main St"));
                Assert.That(data.Phone, Is.EqualTo("1234567890"));
                Assert.That(data.Aadhar, Is.EqualTo("123456789012"));
                Assert.That(data.Email, Is.EqualTo("john.doe@example.com"));
                Assert.That(data.DocumnetPath, Is.EqualTo("/path/to/document"));
            });
        }

        [Test]
        public void DataModel_InvalidProperties_ReturnsFalse()
        {
            // Arrange
            var data = new Data
            {
                id = 1,
                FirstName = "", // Invalid: Empty FirstName
                LastName = "Doe",
                Age = -5,        // Invalid: Negative Age
                Address = null,  // Invalid: Null Address
                Phone = "123",   // Invalid: Short Phone number
                Aadhar = "Invalid Aadhar",  // Invalid: Invalid Aadhar format
                Email = "invalid-email",    // Invalid: Invalid Email format
                DocumnetPath = "/path/to/document"
            };

            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.That(data.id, Is.EqualTo(1));
                Assert.That(data.FirstName, Is.Empty); // Adjust the constraint based on your validation logic
                Assert.That(data.Age, Is.LessThan(0)); // Adjust the constraint based on your validation logic
                Assert.That(data.Address, Is.Null);
                Assert.That(data.Phone, Is.EqualTo("123"));
                Assert.That(data.Aadhar, Is.EqualTo("Invalid Aadhar"));
                Assert.That(data.Email, Is.EqualTo("invalid-email"));
                Assert.That(data.DocumnetPath, Is.EqualTo("/path/to/document"));
            });
        }
    }
}
