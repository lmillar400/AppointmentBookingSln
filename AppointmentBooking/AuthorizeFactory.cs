using AppointmentBooking.Enums;

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
