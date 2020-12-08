using AppointmentBooking;
using AppointmentBooking.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class PractitionerAuthTests
    {
        [TestCase(Tasks.ViewPatients, false)]
        [TestCase(Tasks.CreatePatients, false)]
        [TestCase(Tasks.EditPatients, false)]
        [TestCase(Tasks.DeletePatients, false)]
        [TestCase(Tasks.CreateAppointments, false)]
        [TestCase(Tasks.EditAppointments, false)]
        [TestCase(Tasks.DeleteAppointments, false)]
        [TestCase(Tasks.ViewAppointments, false)]
        [TestCase(Tasks.CreateUsers, false)]
        [TestCase(Tasks.EditUsers, false)]
        [TestCase(Tasks.DeleteUsers, false)]
        [TestCase(Tasks.ViewUsers, false)]
        [TestCase(Tasks.ViewPatientHistory, true)]
        [TestCase(Tasks.ViewPatientNotes, true)]
        [TestCase(Tasks.CreatePatientNotes, true)]
        [TestCase(Tasks.ViewParctitionerAppointments, true)]
        [TestCase(Tasks.ViewParctitionerPatients, true)]
        public void Authorize_PractitionerStaffRole_ExpectedAuthorizationReturned(Tasks task, bool expectedResult)
        {
            //Arrange
            PractitionerAuth authorizer = new PractitionerAuth();

            //Act
            var result = authorizer.Authorize(task);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
