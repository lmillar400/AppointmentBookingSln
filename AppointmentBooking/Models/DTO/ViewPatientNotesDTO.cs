using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Models.DTO
{
    public class ViewPatientNotesDTO
    {
        public List<PatientNoteModel> PatientNotes { get; set; }
        public PatientModel PatientDetails { get; set; }
    }
}
