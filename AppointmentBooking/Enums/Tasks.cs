using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Enums
{
    public enum Tasks
    {
        //Tasks related to managing patients - admin, reception staff
        ViewPatients,
        CreatePatients,
        EditPatients,
        DeletePatients,

        //Tasks related to managing appointments - admin, reception staff
        CreateAppointments,
        EditAppointments,
        DeleteAppointments,
        ViewAppointments,

        //Tasks related to managing users - admin
        CreateUsers,
        EditUsers,
        DeleteUsers,
        ViewUsers,

        //Tasks related to managing Practitioner patients - practitioner staff only
        ViewPatientHistory,
        ViewPatientNotes,
        CreatePatientNotes,
        ViewParctitionerAppointments,
        ViewParctitionerPatients
    }
}
