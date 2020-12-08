﻿using System;
using AppointmentBooking.Enums;

namespace AppointmentBooking
{
    public class AuthorizeEngine
    {
        public bool Authorize(Tasks task, int role)
        {
            try
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
            catch(Exception)
            {
                throw;
            }
        }
    }
}
