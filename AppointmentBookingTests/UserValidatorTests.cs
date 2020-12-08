using AppointmentBooking.Models;
using AppointmentBooking.ModelValidators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class UserValidatorTests
    {
        [Test]
        public void Validate_ValidModel_ReturnsTrue()
        {
            //Arrange
            UserValidator validator = new UserValidator();
            var model = new UserModel { UserId = 1, FirstName = "Joe", LastName = "Bloggs", UserName = "admin", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsTrue(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Validate_InValidFirstName_ReturnsFalse(string firstName)
        {
            //Arrange
            UserValidator validator = new UserValidator();
            var model = new UserModel { UserId = 1, FirstName = firstName, LastName = "Bloggs", UserName = "admin", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Validate_InValidLastName_ReturnsFalse(string lastName)
        {
            //Arrange
            UserValidator validator = new UserValidator();
            var model = new UserModel { UserId = 1, FirstName = "Joe", LastName = lastName, UserName = "admin", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Validate_InValidUserName_ReturnsFalse(string userName)
        {
            //Arrange
            UserValidator validator = new UserValidator();
            var model = new UserModel { UserId = 1, FirstName = "Joe", LastName = "username", UserName = userName, PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Validate_InValidPasswordHash_ReturnsFalse(string password)
        {
            //Arrange
            UserValidator validator = new UserValidator();
            var model = new UserModel { UserId = 1, FirstName = "Joe", LastName = "username", UserName = "admin", PasswordHash = password, PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]

        public void Validate_InValidPasswordSalt_ReturnsFalse(string passwordSalt)
        {
            //Arrange
            UserValidator validator = new UserValidator();
            var model = new UserModel { UserId = 1, FirstName = "Joe", LastName = "username", UserName = "admin", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = passwordSalt, IsDeleted = false, UserRoleId = 1 };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
