using AppointmentBooking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking
{
    public class AuthorizeEngine
    {
        public bool Authorize(Tasks task, int role)
        {

            var factory = new AuthorizeFactory();

            Roles roleEnum = (Roles)role;

            var roleAuth = factory.Create(roleEnum);
            if (roleAuth == null)
            {
                return false;
            }

            bool authorization = roleAuth.Authorize(task);

            return authorization;


        }
    }
}
