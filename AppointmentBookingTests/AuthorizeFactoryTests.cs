using AppointmentBooking;
using AppointmentBooking.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class AuthorizeFactoryTests
    {
        [Test]
        public void Create_AdminStaffRole_AdminStaffAuthIsReturned()
        {
            //Arrange
            AuthorizeFactory factory = new AuthorizeFactory();
            Roles role = Roles.AdminStaff;

            //Act
            var authType = factory.Create(role);

            //Assert
            Assert.That(authType, Is.TypeOf<AdminStaffAuth>());
        }

        [Test]
        public void Create_ReceptionStaffRole_ReceptionStaffAuthIsReturned()
        {
            //Arrange
            AuthorizeFactory factory = new AuthorizeFactory();
            Roles role = Roles.ReceptionStaff;

            //Act
            var authType = factory.Create(role);

            //Assert
            Assert.That(authType, Is.TypeOf<ReceptionStaffAuth>());
        }

        [Test]
        public void Create_PractitionerStaffRole_PractitionerStaffAuthIsReturned()
        {
            //Arrange
            AuthorizeFactory factory = new AuthorizeFactory();
            Roles role = Roles.Practitioner;

            //Act
            var authType = factory.Create(role);

            //Assert
            Assert.That(authType, Is.TypeOf<PractitionerAuth>());
        }
    }
}
