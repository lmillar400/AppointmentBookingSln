using NUnit.Framework;
using AppointmentBooking;
using AppointmentBooking.Enums;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class AdminStaffAuthTests
    {
        [TestCase(Tasks.ViewPatients, true)]
        [TestCase(Tasks.CreatePatients, true)]
        [TestCase(Tasks.EditPatients, true)]
        [TestCase(Tasks.DeletePatients, true)]
        [TestCase(Tasks.CreateAppointments, true)]
        [TestCase(Tasks.EditAppointments, true)]
        [TestCase(Tasks.DeleteAppointments, true)]
        [TestCase(Tasks.ViewAppointments, true)]
        [TestCase(Tasks.CreateUsers, true)]
        [TestCase(Tasks.EditUsers, true)]
        [TestCase(Tasks.DeleteUsers, true)]
        [TestCase(Tasks.ViewUsers, true)]
        [TestCase(Tasks.ViewPatientHistory, false)]
        [TestCase(Tasks.ViewPatientNotes, false)]
        [TestCase(Tasks.CreatePatientNotes, false)]
        [TestCase(Tasks.ViewParctitionerAppointments, false)]
        [TestCase(Tasks.ViewParctitionerPatients, false)]
        public void Authorize_AdminStaffRole_ExpectedAuthorizationReturned(Tasks task, bool expectedResult)
        {
            //Arrange
            AdminStaffAuth authorizer = new AdminStaffAuth();

            //Act
            var result = authorizer.Authorize(task);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
