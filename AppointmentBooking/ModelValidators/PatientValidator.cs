using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.ModelValidators
{
    public class PatientValidator : IModelValidator<PatientModel>
    {
        public bool Validate(PatientModel model)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(model.FirstName))
            {
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(model.LastName))
            {
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(model.TelephoneNumber))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
