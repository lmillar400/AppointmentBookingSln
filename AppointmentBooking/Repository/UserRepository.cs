using AppointmentBooking.Models;
using System.Linq;

namespace AppointmentBooking.Repository
{
    public class UserRepository: GenericRepository<UserModel>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public UserModel GetUserByUserName(string username)
        {
            return _appDbContext.User.FirstOrDefault(user => user.UserName == username);
        }
    }
}
