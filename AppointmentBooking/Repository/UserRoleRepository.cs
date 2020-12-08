using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Repository
{
    public class UserRoleRepository: GenericRepository<UserRoleModel>, IUserRoleRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRoleRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
    }
}
