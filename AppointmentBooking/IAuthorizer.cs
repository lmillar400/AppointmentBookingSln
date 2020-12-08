using AppointmentBooking.Enums;

namespace AppointmentBooking
{
    public interface IAuthorizer
    {
        bool Authorize(Tasks task);
    }
}
