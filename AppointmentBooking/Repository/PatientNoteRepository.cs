using AppointmentBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentBooking.Repository
{
    public class PatientNoteRepository : GenericRepository<PatientNoteModel>, IPatientNoteRepository
    {
        private readonly AppDbContext _appDbContext;

        public PatientNoteRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public List<PatientNoteModel> GetPatientNotesByPatientIdAndPractitionerId(int patientId, int practitionerId)
        {
            return _appDbContext.PatientNote.Where(note => note.PatientId == patientId && note.PractitionerId == practitionerId).ToList();
        }
    }
}
