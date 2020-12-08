using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Repository
{
    public interface IAppointmentRepository : IGenericRepository<AppointmentModel>
    {
        List<AppointmentModel> GetAppointmentsByPractitionerId(int practitionerId);
        List<AppointmentModel> GetAppointmentsByPractitionerIdAndPatientId(int practitionerId, int patientId);
    }
}
