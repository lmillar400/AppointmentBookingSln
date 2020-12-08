using AppointmentBooking.Controllers;
using AppointmentBooking.Models;
using AppointmentBooking.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AppointmentBooking.Models.DTO;
using AppointmentBooking.ModelValidators;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class AppointmentControllerTests
    {
        public Mock<ILogger<AppointmentController>> logger;
        public Mock<IUserRepository> userRepo;
        public Mock<IPractitionerRepository> practitionerRepo;
        public Mock<IAppointmentRepository> appointmentRepo;
        public Mock<IPatientRepository> patientRepo;
        public Mock<IModelValidator<AppointmentModel>> validator;


        [SetUp]
        public void Init()
        {
            userRepo = new Mock<IUserRepository>();
            logger = new Mock<ILogger<AppointmentController>>();
            practitionerRepo = new Mock<IPractitionerRepository>();
            patientRepo = new Mock<IPatientRepository>();
            appointmentRepo = new Mock<IAppointmentRepository>();
            validator = new Mock<IModelValidator<AppointmentModel>>();
        }

        [Test]
        public void ViewAppointments_ValidData_GeneratesAppointmentsDTO()
        {
            //Arrange
            appointmentRepo.Setup(repo => repo.GetAll()).Returns(GetAppointmentRecords());
            patientRepo.Setup(repo => repo.GetById(1)).Returns(new PatientModel { PatientId = 1, FirstName = "Niall", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });
            patientRepo.Setup(repo => repo.GetById(2)).Returns(new PatientModel { PatientId = 1, FirstName = "Mary", LastName = "Canning", Email = "mary@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });
            patientRepo.Setup(repo => repo.GetById(3)).Returns(new PatientModel { PatientId = 1, FirstName = "Elaine", LastName = "Cummings", Email = "elaine@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });

            practitionerRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new PractitionerModel { PractitionerId = 1, PractitionerName = "Dentist" });


            var controller = new AppointmentController(logger.Object, appointmentRepo.Object,practitionerRepo.Object,patientRepo.Object,userRepo.Object,validator.Object);

            var result = controller.ViewAppointments() as ViewResult;
            var modelList = result.ViewData.Model as List<AppointmentViewDTO>;
            Assert.That(modelList.Count.Equals(3));
        }

        [Test]
        public void CreateAppointmentAction_LoadsCreateAppointmentPage_ReturnsCreateAppointmentView()
        {
            //Arrange
            var controller = new AppointmentController(logger.Object, appointmentRepo.Object, practitionerRepo.Object, patientRepo.Object, userRepo.Object, validator.Object);

            //Act
            var result = controller.CreateAppointment() as ViewResult;

            //Assert
            Assert.AreEqual("CreateAppointment", result.ViewName);
        }

        [Test]
        public void EditAppointmentAction_LoadsValidAppointment_ReturnsViewWithModel()
        {
            //Arrange
            appointmentRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new AppointmentModel { AppointmentId = 1, AppointmentDateTime = DateTime.Now, PatientId = 1, PractitionerId = 1 });

            var controller = new AppointmentController(logger.Object, appointmentRepo.Object, practitionerRepo.Object, patientRepo.Object, userRepo.Object, validator.Object);

            //Act
            var result = controller.EditAppointment(1) as ViewResult;

            //Assert
            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void EditAppointmentAction_LoadsNullAppointment_ReturnsNotFound()
        {
            //Arrange
            AppointmentModel nullAppointment = null;
            appointmentRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(nullAppointment);

            var controller = new AppointmentController(logger.Object, appointmentRepo.Object, practitionerRepo.Object, patientRepo.Object, userRepo.Object, validator.Object);

            //Act
            var result = controller.EditAppointment(1);

            // Assert
            Assert.IsInstanceOf(typeof(NotFoundResult),result);
        }

        [Test]
        public void UpdateAppointmentAction_NullAppointment_ReturnsBadRequest()
        {
            //Arrange
            var controller = new AppointmentController(logger.Object, appointmentRepo.Object, practitionerRepo.Object, patientRepo.Object, userRepo.Object, validator.Object);

            //Act
            var result = controller.UpdateAppointment(null);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public void UpdateAppointmentAction_ValidAppointment_ReturnsRedirectToAction()
        {
            //Arrange
            var validAppointment = new AppointmentModel { AppointmentId = 1, AppointmentDateTime = DateTime.Now, PatientId = 1, PractitionerId = 1 };
            validator.Setup(repo => repo.Validate(It.IsAny<AppointmentModel>())).Returns(true);

            var controller = new AppointmentController(logger.Object, appointmentRepo.Object, practitionerRepo.Object, patientRepo.Object, userRepo.Object, validator.Object);

            //Act
            var result = controller.UpdateAppointment(validAppointment) as RedirectToActionResult;

            // Assert
            Assert.That(result.ActionName, Is.EqualTo("ViewAppointments"));
        }

        [Test]
        public void DeleteAppointmentAction_ValidDelete_RedirectsToViewAppointments()
        {
            //Arrange
            var controller = new AppointmentController(logger.Object, appointmentRepo.Object, practitionerRepo.Object, patientRepo.Object, userRepo.Object, validator.Object);

            //Act
            var result = controller.DeleteAppointment(It.IsAny<int>()) as RedirectToActionResult;

            // Assert
            Assert.That(result.ActionName, Is.EqualTo("ViewAppointments"));
        }

        private IEnumerable<AppointmentModel> GetAppointmentRecords()
        {
            List<AppointmentModel> list = new List<AppointmentModel>();

            list.Add(new AppointmentModel { AppointmentId = 1, AppointmentDateTime = DateTime.Now, PatientId = 1, PractitionerId = 1 });
            list.Add(new AppointmentModel { AppointmentId = 2, AppointmentDateTime = DateTime.Now, PatientId = 2, PractitionerId = 2 });
            list.Add(new AppointmentModel { AppointmentId = 3, AppointmentDateTime = DateTime.Now, PatientId = 3, PractitionerId = 1 });

            IEnumerable<AppointmentModel> en = list;
            return en;
        }
    }
}
