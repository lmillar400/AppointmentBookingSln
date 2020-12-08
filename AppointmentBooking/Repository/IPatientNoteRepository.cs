using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Repository
{
    public interface IPatientNoteRepository : IGenericRepository<PatientNoteModel>
    {
        List<PatientNoteModel> GetPatientNotesByPatientIdAndPractitionerId(int patientId, int practitionerId);
    }
}
