using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Models.DTO
{
    public class AppointmentCreateDTO
    {
        public IEnumerable<PatientModel> Patients { get; set; }
        public IEnumerable<PractitionerModel> Practices { get; set; }
    }
}
