using AppointmentBooking.Enums;
using AppointmentBooking.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking
{
    public class AuthorizeFactory
    {
        public IAuthorizer Create(Roles role)
        {
            switch (role)
            {
                case Roles.AdminStaff:
                    return new AdminStaffAuth();

                case Roles.ReceptionStaff:
                    return new ReceptionStaffAuth();

                case Roles.Practitioner:
                    return new PractitionerAuth();

                default:
                    return null;
            }
        }
    }
}
