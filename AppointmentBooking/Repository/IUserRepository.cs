﻿using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Repository
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        UserModel GetUserByUserName(string userName);
    }
}
