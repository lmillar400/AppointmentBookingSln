using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.ModelValidators
{
    public class PatientNoteValidator : IModelValidator<PatientNoteModel>
    {
        public bool Validate(PatientNoteModel model)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(model.NoteDescription))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
