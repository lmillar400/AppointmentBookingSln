using AppointmentBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking
{
    public class PractitionerAuth : IAuthorizer
    {
        private List<Tasks> allowedTasks;
        public PractitionerAuth()
        {
            PopulateAllowedTasks();
        }
        public bool Authorize(Tasks task)
        {
            if (allowedTasks.Contains(task))
            {
                return true;
            }
            return false;
        }

        private void PopulateAllowedTasks()
        {
            allowedTasks = new List<Tasks> {
                Tasks.ViewParctitionerAppointments,
                Tasks.ViewPatientHistory,
                Tasks.CreatePatientNotes,
                Tasks.ViewPatientNotes,
                Tasks.ViewParctitionerPatients
            };
        }
    }
}
