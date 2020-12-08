using NUnit.Framework;
using AppointmentBooking;
using AppointmentBooking.Enums;

namespace AppointmentBookingTests
{
    [TestFixture]
    public class AuthorizeEngineTests
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
        public void Authorize_TestUsingAdminStaffRole_ExpedAuthorization(Tasks task, bool expectedOutcome)
        {
            //Arrange
            AuthorizeEngine engine = new AuthorizeEngine();
            int adminStaffRoleId = 1;

            //Act
            bool authorization = engine.Authorize(task, adminStaffRoleId);

            //Assert
            Assert.That(authorization, Is.EqualTo(expectedOutcome));

        }

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
        public void Authorize_TestUsingReceptionStaffRole_ExpedAuthorization(Tasks task, bool expectedOutcome)
        {
            //Arrange
            AuthorizeEngine engine = new AuthorizeEngine();
            int receptionStaffRoleId = 2;

            //Act
            bool authorization = engine.Authorize(task, receptionStaffRoleId);

            //Assert
            Assert.That(authorization, Is.EqualTo(expectedOutcome));
        }

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
        public void Authorize_TestUsingPractitionerStaffRole_ExpedAuthorization(Tasks task, bool expectedOutcome)
        {
            //Arrange
            AuthorizeEngine engine = new AuthorizeEngine();
            int practitionerStaffRoleId = 3;

            //Act
            bool authorization = engine.Authorize(task, practitionerStaffRoleId);

            //Assert
            Assert.That(authorization, Is.EqualTo(expectedOutcome));
        }

        [Test]
        public void Authorize_UsingInvalidRoleId_ExpedAuthorization()
        {
            //Arrange
            AuthorizeEngine engine = new AuthorizeEngine();
            int invalidRoleId = -1;

            //Act
            bool authorization = engine.Authorize(Tasks.ViewAppointments, invalidRoleId);

            //Assert
            Assert.That(authorization, Is.EqualTo(false));

        }
    }
}
