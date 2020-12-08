using AppointmentBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking
{
    public interface IAuthorizer
    {
        bool Authorize(Tasks task);
    }
}
