using AppointmentBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.ModelValidators
{
    public class UserValidator: IModelValidator<UserModel>
    {
        public bool Validate(UserModel user)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(user.PasswordSalt))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
