using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using AppointmentBooking.Controllers;
using AppointmentBooking.Helpers;
using AppointmentBooking.Models;
using AppointmentBooking.Repository;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        Mock<ILogger<HomeController>> logger;
        Mock<IUserRepository> userRepo;
        Mock<ICryptographyHelper> crypto;

        [SetUp]
        public void Init()
        {
            logger = new Mock<ILogger<HomeController>>();
            userRepo = new Mock<IUserRepository>();
            crypto = new Mock<ICryptographyHelper>();
        }

        [Test]
        public void LoginAction_LoadLoginPage_ReturnsLoginView()
        {
            //Arrange
            var controller = new HomeController(logger.Object, userRepo.Object, crypto.Object);

            //Act
            var result = controller.Login() as ViewResult;

            //Assert
            Assert.AreEqual("Login", result.ViewName);
        }

        [Test]
        public void IndexAction_LoadIndexPage_ReturnsIndexView()
        {
            //Arrange
            var controller = new HomeController(logger.Object, userRepo.Object, crypto.Object);

            //Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestCase("username", "password")]
        [TestCase("", "password")]
        [TestCase("username", "")]
        [TestCase(null, "password")]
        [TestCase("username", null)]
        public void LoginAction_InvalidCredentials_ReturnsIndexViewResult(string username, string password)
        {
            //Arrange
            userRepo.Setup(repo => repo.GetUserByUserName(It.IsAny<string>())).Returns(new UserModel { UserId = 1, FirstName = "Joe", LastName = "Bloggs", UserName = "username1", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 });
            var controller = new HomeController(logger.Object, userRepo.Object, crypto.Object);

            //Act
            var result = controller.Login(username, password);

            var actResult = (LocalRedirectResult)result;

            //Assert
            Assert.AreEqual("/Home/Login?error=1", actResult.Url);
        }

    }
}