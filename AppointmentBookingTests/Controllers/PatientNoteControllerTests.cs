using AppointmentBooking.Controllers;
using AppointmentBooking.Models;
using AppointmentBooking.ModelValidators;
using AppointmentBooking.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class PatientNoteControllerTests
    {
        public Mock<IUserRepository> userRepo;
        public Mock<IPatientNoteRepository> patientNoteRepo;
        public Mock<IPatientRepository> patientRepo;
        public Mock<IModelValidator<PatientNoteModel>> validatorRepo;

        [SetUp]
        public void Init()
        {
            userRepo = new Mock<IUserRepository>();
            patientNoteRepo = new Mock<IPatientNoteRepository>();
            patientRepo = new Mock<IPatientRepository>();
            validatorRepo = new Mock<IModelValidator<PatientNoteModel>>();
        }

        [Test]
        public void InsertPatientActionResult_ValidPatientModel_RedirectToIndexView()
        {
            //Arrange
            PatientNoteModel validModel = new PatientNoteModel { PatientId = 1, PractitionerId = 1, NoteId = 1, NoteDescription = "Description", CreationDate = DateTime.Now};
            var controller = new PatientNoteController(userRepo.Object, patientNoteRepo.Object, patientRepo.Object, validatorRepo.Object);
            validatorRepo.Setup(repo => repo.Validate(It.IsAny<PatientNoteModel>())).Returns(true);

            //Act
            var result = controller.InsertPatientNote(validModel) as RedirectToActionResult;

            // Assert
            Assert.That(result.ActionName, Is.EqualTo("ViewPatientNotes"));
        }

        [Test]
        public void InsertPatientActionResult_NullPatientModel_ReturnBadRequest()
        {
            //Arrange
            var controller = new PatientNoteController(userRepo.Object, patientNoteRepo.Object, patientRepo.Object, validatorRepo.Object);

            //Act
            var result = controller.InsertPatientNote(null);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }
    }
}
