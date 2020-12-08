using System.Collections.Generic;
using System.Linq;
using AppointmentBooking.Models;

namespace AppointmentBooking.Repository
{
    public class AppointmentRepository : GenericRepository<AppointmentModel>, IAppointmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public AppointmentRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public List<AppointmentModel> GetAppointmentsByPractitionerId(int practitionerId)
        {
            return _appDbContext.Appointment.Where(app => app.PractitionerId == practitionerId).ToList();
        }

        public List<AppointmentModel> GetAppointmentsByPractitionerIdAndPatientId(int practitionerId, int patientId)
        {
            return _appDbContext.Appointment.Where(app => app.PractitionerId == practitionerId && app.PatientId == patientId).ToList();
        }
    }
}
