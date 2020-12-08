using AppointmentBooking.Models;

namespace AppointmentBooking.Repository
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        UserModel GetUserByUserName(string userName);
    }
}
