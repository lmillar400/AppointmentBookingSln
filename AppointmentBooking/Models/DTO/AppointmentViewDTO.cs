using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Models.DTO
{
    public class AppointmentViewDTO
    {
        public int AppointmentId { get; set; }
        public string PracticeName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientTelNo { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
