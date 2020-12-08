using AppointmentBooking;
using AppointmentBooking.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class ReceptionStaffAuthTests
    {
        [TestCase(Tasks.ViewPatients, true)]
        [TestCase(Tasks.CreatePatients, true)]
        [TestCase(Tasks.EditPatients, true)]
        [TestCase(Tasks.DeletePatients, true)]
        [TestCase(Tasks.CreateAppointments, true)]
        [TestCase(Tasks.EditAppointments, true)]
        [TestCase(Tasks.DeleteAppointments, true)]
        [TestCase(Tasks.ViewAppointments, true)]
        [TestCase(Tasks.CreateUsers, false)]
        [TestCase(Tasks.EditUsers, false)]
        [TestCase(Tasks.DeleteUsers, false)]
        [TestCase(Tasks.ViewUsers, false)]
        [TestCase(Tasks.ViewPatientHistory, false)]
        [TestCase(Tasks.ViewPatientNotes, false)]
        [TestCase(Tasks.CreatePatientNotes, false)]
        [TestCase(Tasks.ViewParctitionerAppointments, false)]
        [TestCase(Tasks.ViewParctitionerPatients, false)]
        public void Authorize_ReceptionStaffRole_ExpectedAuthorizationReturned(Tasks task, bool expectedResult)
        {
            //Arrange
            ReceptionStaffAuth authorizer = new ReceptionStaffAuth();

            //Act
            var result = authorizer.Authorize(task);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
