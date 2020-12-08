using System.Collections.Generic;
using AppointmentBooking.Models;

namespace AppointmentBooking.Repository
{
    public interface IAppointmentRepository : IGenericRepository<AppointmentModel>
    {
        List<AppointmentModel> GetAppointmentsByPractitionerId(int practitionerId);
        List<AppointmentModel> GetAppointmentsByPractitionerIdAndPatientId(int practitionerId, int patientId);
    }
}
