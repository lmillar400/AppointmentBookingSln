using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using AppointmentBooking.Controllers;
using AppointmentBooking.Models;
using AppointmentBooking.ModelValidators;
using AppointmentBooking.Repository;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class PatientControllerTests
    {
        public Mock<ILogger<PatientController>> logger;
        public Mock<IPatientRepository> patientRepo;
        public Mock<IModelValidator<PatientModel>> validator;

        [SetUp]
        public void Init()
        {
            logger = new Mock<ILogger<PatientController>>();
            patientRepo = new Mock<IPatientRepository>();
            validator = new Mock<IModelValidator<PatientModel>>();
        }

        [Test]
        public void IndexActionResult_ValidData_ModelIsTransferedToView()
        {
            //Arrange
            patientRepo.Setup(repo => repo.GetAll()).Returns(GetPatientRecords());

            var controller = new PatientController(logger.Object, patientRepo.Object, validator.Object);
            
            var result = controller.Index() as ViewResult;
            var modelList = result.ViewData.Model as List<PatientModel>;
            Assert.That(modelList.Count.Equals(5));
        }

        [Test]
        public void EditPatientActionResult_ValidData_ModelIsTransferedToView()
        {
            //Arrange
            PatientModel nullModel = null;

            patientRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(nullModel);

            var controller = new PatientController(logger.Object, patientRepo.Object, validator.Object);

            var result = controller.EditPatient(It.IsAny<int>());

            // Assert
            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }
        [Test]
        public void UpdatePatientActionResult_ValidPatientModel_RedirectToIndexView()
        {
            //Arrange
            PatientModel validModel = new PatientModel { PatientId = 1, FirstName = "Niall", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" };
            var controller = new PatientController(logger.Object, patientRepo.Object, validator.Object);
            validator.Setup(repo => repo.Validate(It.IsAny<PatientModel>())).Returns(true);

            //Act
            var result = controller.UpdatePatient(validModel) as RedirectToActionResult;

            // Assert
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void UpdatePatientActionResult_NullPatientModel_ReturnBadRequest()
        {
            //Arrange
            var controller = new PatientController(logger.Object, patientRepo.Object, validator.Object);

            //Act
            var result = controller.UpdatePatient(null);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public void InsertPatientActionResult_ValidPatientModel_RedirectToIndexView()
        {
            //Arrange
            PatientModel validModel = new PatientModel { PatientId = 1, FirstName = "Niall", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" };
            var controller = new PatientController(logger.Object, patientRepo.Object, validator.Object);
            validator.Setup(repo => repo.Validate(It.IsAny<PatientModel>())).Returns(true);

            //Act
            var result = controller.InsertPatient(validModel) as RedirectToActionResult;

            // Assert
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void InsertPatientActionResult_NullPatientModel_ReturnBadRequest()
        {
            //Arrange
            var controller = new PatientController(logger.Object, patientRepo.Object, validator.Object);

            //Act
            var result = controller.InsertPatient(null);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public void DeletePatientActionResult_ValidDelete_RedirectsToViewPatients()
        {
            //Arrange
            var controller = new PatientController(logger.Object, patientRepo.Object, validator.Object);

            //Act
            var result = controller.DeletePatient(It.IsAny<int>()) as RedirectToActionResult;

            // Assert
            Assert.That(result.ActionName, Is.EqualTo("Index"));
        }

        private IEnumerable<PatientModel> GetPatientRecords()
        {
            List<PatientModel> list = new List<PatientModel>();

            list.Add(new PatientModel { PatientId = 1, FirstName = "Niall", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });
            list.Add(new PatientModel { PatientId = 1, FirstName = "Shane", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });
            list.Add(new PatientModel { PatientId = 1, FirstName = "Liam", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });
            list.Add(new PatientModel { PatientId = 1, FirstName = "Carla", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });
            list.Add(new PatientModel { PatientId = 1, FirstName = "Micheal", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });

            IEnumerable<PatientModel> en = list;
            return en;
        }
    }
}
