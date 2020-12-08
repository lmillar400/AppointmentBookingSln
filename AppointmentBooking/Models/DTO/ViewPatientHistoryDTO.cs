using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Models.DTO
{
    public class ViewPatientHistoryDTO
    {
        public PatientModel Patient { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int AppointmentId { get; set; }
    }
}
