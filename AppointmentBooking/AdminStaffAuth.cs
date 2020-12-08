using AppointmentBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking
{
    public class AdminStaffAuth : IAuthorizer
    {
        private List<Tasks> allowedTasks;
        public AdminStaffAuth()
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
            allowedTasks = new List<Tasks>{ 
                //Manage Appointments
                Tasks.ViewAppointments,
                Tasks.CreateAppointments,
                Tasks.EditAppointments,
                Tasks.DeleteAppointments,

                //Manage Patients
                Tasks.ViewPatients,
                Tasks.CreatePatients,
                Tasks.EditPatients,
                Tasks.DeletePatients,

                //Manage Users
                Tasks.ViewUsers,
                Tasks.CreateUsers,
                Tasks.EditUsers,
                Tasks.DeleteUsers
            };
        }
    }
}
