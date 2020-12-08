using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Helpers
{
    public interface ICryptographyHelper
    {
        string CreateSalt();
        string GenerateHash(string input, string salt);
        bool AreEqual(string plainTextInput, string hashedInput, string salt);
    }
}
