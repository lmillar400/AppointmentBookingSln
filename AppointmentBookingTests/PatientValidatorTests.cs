using AppointmentBooking.Models;
using AppointmentBooking.ModelValidators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentBookingTests
{
    [TestFixture]
    class PatientValidatorTests
    {
        [Test]
        public void Validate_ValidModel_ReturnsTrue()
        {
            //Arrange
            PatientValidator validator = new PatientValidator();
            var model = new PatientModel { PatientId = 4, FirstName = "Eoin", LastName = "Campbell", Email = "eoin@email.com", TelephoneNumber = "02877741764", MobileNumber = "74477474" };

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
            PatientValidator validator = new PatientValidator();
            var model = new PatientModel { PatientId = 4, FirstName = firstName, LastName = "Campbell", Email = "eoin@email.com", TelephoneNumber = "02877741764", MobileNumber = "74477474" };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Validate_InValidLasttName_ReturnsFalse(string lastName)
        {
            //Arrange
            PatientValidator validator = new PatientValidator();
            var model = new PatientModel { PatientId = 4, FirstName = "Eoin", LastName = lastName, Email = "eoin@email.com", TelephoneNumber = "02877741764", MobileNumber = "74477474" };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Validate_InValidEmail_ReturnsFalse(string email)
        {
            //Arrange
            PatientValidator validator = new PatientValidator();
            var model = new PatientModel { PatientId = 4, FirstName = "Eoin", LastName = "Campbell", Email = email, TelephoneNumber = "02877741764", MobileNumber = "74477474" };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Validate_InValidTelephoneNumber_ReturnsFalse(string telephoneNumber)
        {
            //Arrange
            PatientValidator validator = new PatientValidator();
            var model = new PatientModel { PatientId = 4, FirstName = "Eoin", LastName = "Campbell", Email = "eoin@email.com", TelephoneNumber = telephoneNumber, MobileNumber = "74477474" };

            //Act
            bool result = validator.Validate(model);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
