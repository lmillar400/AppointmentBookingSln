using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using AppointmentBooking.Controllers;
using AppointmentBooking.Helpers;
using AppointmentBooking.Models;
using AppointmentBooking.ModelValidators;
using AppointmentBooking.Repository;



namespace AppointmentBookingTests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        public Mock<IUserRepository> userRepo;
        public Mock<ILogger<UserController>> logger;
        public Mock<IUserRoleRepository> userRoleRepo;
        public Mock<IPractitionerRepository> practitionerRepo;
        public Mock<IPatientRepository> patientRepo;
        public Mock<ICryptographyHelper> cryptoHelper;
        public Mock<IModelValidator<UserModel>> validator;

        [SetUp]
        public void Init()
        {
            userRepo = new Mock<IUserRepository>();
            logger = new Mock<ILogger<UserController>>();
            userRoleRepo = new Mock<IUserRoleRepository>();
            practitionerRepo = new Mock<IPractitionerRepository>();
            patientRepo = new Mock<IPatientRepository>();
            cryptoHelper = new Mock<ICryptographyHelper>();
            validator = new Mock<IModelValidator<UserModel>>();
        }

        [Test]
        public void ViewUsers_ValidData_CorrectModelToView()
        {
            //Arrange
            userRepo.Setup(repo => repo.GetAll()).Returns(GetUserRecords());

            var controller = new UserController(logger.Object, userRoleRepo.Object, userRepo.Object, practitionerRepo.Object, cryptoHelper.Object, validator.Object);
            //Act
            var result = controller.ViewUsers() as ViewResult;

            //Assert
            var modelList = result.ViewData.Model as List<UserModel>;
            Assert.That(modelList.Count.Equals(6));
        }

        [Test]
        public void CreateUserAction_LoadsCreateUserPage_ReturnsCreateUserView()
        {
            //Arrange
            var controller = new UserController(logger.Object, userRoleRepo.Object, userRepo.Object, practitionerRepo.Object, cryptoHelper.Object, validator.Object);

            //Act
            var result = controller.CreateUser() as ViewResult;

            //Assert
            Assert.AreEqual("CreateUser", result.ViewName);
        }

        [Test]
        public void EditUserAction_LoadsValidUser_ReturnsViewWithModel()
        {
            //Arrange
            userRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(new UserModel { UserId = 1, FirstName = "Joe", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 });
            var controller = new UserController(logger.Object, userRoleRepo.Object, userRepo.Object, practitionerRepo.Object, cryptoHelper.Object, validator.Object);

            //Act
            var result = controller.EditUser(It.IsAny<int>()) as ViewResult;

            //Assert
            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void EditUserAction_LoadsNullUser_ReturnsNotFound()
        {
            //Arrange
            UserModel nullUser = null;
            userRepo.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(nullUser);

            var controller = new UserController(logger.Object, userRoleRepo.Object, userRepo.Object, practitionerRepo.Object, cryptoHelper.Object, validator.Object);

            //Act
            var result = controller.EditUser(It.IsAny<int>());

            // Assert
            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }

        [Test]
        public void UpdateUserAction_NullUser_ReturnsBadRequest()
        {
            //Arrange
            var controller = new UserController(logger.Object, userRoleRepo.Object, userRepo.Object, practitionerRepo.Object, cryptoHelper.Object, validator.Object);

            //Act
            var result = controller.UpdateUser(null);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result);
        }

        [Test]
        public void UpdateUserAction_ValidUser_ReturnsRedirectToAction()
        {
            //Arrange
            var validUser = new UserModel { UserId = 1, FirstName = "Joe", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 };
            var controller = new UserController(logger.Object, userRoleRepo.Object, userRepo.Object, practitionerRepo.Object, cryptoHelper.Object, validator.Object);
            validator.Setup(repo => repo.Validate(It.IsAny<UserModel>())).Returns(true);

            //Act
            var result = controller.UpdateUser(validUser) as RedirectToActionResult;

            // Assert
            Assert.That(result.ActionName, Is.EqualTo("ViewUsers"));
        }

        [Test]
        public void DeleteAppointmentAction_ValidDelete_RedirectsToViewAppointments()
        {
            //Arrange
            var controller = new UserController(logger.Object, userRoleRepo.Object, userRepo.Object, practitionerRepo.Object, cryptoHelper.Object, validator.Object);

            //Act
            var result = controller.DeleteUser(It.IsAny<int>()) as RedirectToActionResult;

            // Assert
            Assert.That(result.ActionName, Is.EqualTo("ViewUsers"));
        }

        private IEnumerable<UserModel> GetUserRecords()
        {
            List<UserModel> list = new List<UserModel>();

            list.Add(new UserModel { UserId = 1, FirstName = "Joe", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 });
            list.Add(new UserModel { UserId = 2, FirstName = "lisa", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 });
            list.Add(new UserModel { UserId = 3, FirstName = "lauren", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 });
            list.Add(new UserModel { UserId = 4, FirstName = "ben", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 });
            list.Add(new UserModel { UserId = 5, FirstName = "jimmy", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 });
            list.Add(new UserModel { UserId = 6, FirstName = "Bernie", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 });

            IEnumerable<UserModel> enumerableCollection = list;
            return enumerableCollection;
        }
    }
}
