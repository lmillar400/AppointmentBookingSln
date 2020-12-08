using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
