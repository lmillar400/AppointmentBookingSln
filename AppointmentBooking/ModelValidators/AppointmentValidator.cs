using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.ModelValidators
{
    public class AppointmentValidator : IModelValidator<AppointmentModel>
    {
        public bool Validate(AppointmentModel appointment)
        {
            bool isValid = true;

            if (appointment.AppointmentDateTime == null)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
