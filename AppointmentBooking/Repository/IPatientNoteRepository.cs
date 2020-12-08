using System.Collections.Generic;
using AppointmentBooking.Models;

namespace AppointmentBooking.Repository
{
    public interface IPatientNoteRepository : IGenericRepository<PatientNoteModel>
    {
        List<PatientNoteModel> GetPatientNotesByPatientIdAndPractitionerId(int patientId, int practitionerId);
    }
}
