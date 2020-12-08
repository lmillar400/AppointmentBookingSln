using AppointmentBooking.Models;

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
