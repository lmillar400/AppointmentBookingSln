using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.Models
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<PatientModel> Patient { get; set; }
        public DbSet<AppointmentModel> Appointment { get; set; }
        public DbSet<PractitionerModel> Practice { get; set; }
        public DbSet<PatientNoteModel> PatientNote { get; set; }
        public DbSet<UserRoleModel> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed users
            modelBuilder.Entity<UserModel>().HasData(new UserModel { UserId = 1, FirstName = "Joe", LastName = "Bloggs", UserName = "admin", PasswordHash = "UNZLw9YDS1z22bSxQsfydF8lb802GaLF0nbaegFJKks=", PasswordSalt = "8ObiA+LM9t9VASwrT5PFe+jZYQhsBFyq9NPipRGj3e0Z8rvt44uB8V8V53n6ftlbEbtLDaqx1M0xRikTz2lzAQ==", IsDeleted = false, UserRoleId = 1 }); //password1
            modelBuilder.Entity<UserModel>().HasData(new UserModel { UserId = 2, FirstName = "Sarah", LastName = "Kelly", UserName = "reception", PasswordHash = "kS/hbAdIb2QwTRr2wfqW7jLaochIs09hW5AAEZ6h0Mc=", PasswordSalt = "1tilkvWD5AfSfK5FsnUk3LOmsM6Rjp2hBfkQnd57BnIdD32mgdpA3VPENMJW2799ij4hw7TZUbiBpcOxXF3XxA==", IsDeleted = false, UserRoleId = 2 }); //password2
            modelBuilder.Entity<UserModel>().HasData(new UserModel { UserId = 3, FirstName = "Paul", LastName = "Anderson", UserName = "practitioner", PasswordHash = "b3vCAn9cRm9rcIA+PPTyBcwi5aY7NFKlSM0Zimx9D/s=", PasswordSalt = "YHwO5Ti8DoU6BlLenehDE+UdKYlWEeRatUEuOl+xL0CnwQrk/4/G+rtyIsug3heT5Buwi4WRcZoeG5I7x7oX5A==", IsDeleted = false, UserRoleId = 3, PractitionerId = 1 }); //password3

            //seed user roles
            modelBuilder.Entity<UserRoleModel>().HasData(new UserRoleModel { UserRoleId = 1, RoleDescription = "Practice Admin Staff" });
            modelBuilder.Entity<UserRoleModel>().HasData(new UserRoleModel { UserRoleId = 2, RoleDescription = "Reception Staff" });
            modelBuilder.Entity<UserRoleModel>().HasData(new UserRoleModel { UserRoleId = 3, RoleDescription = "Medical Parctitioner" });

            //seed patients
            modelBuilder.Entity<PatientModel>().HasData(new PatientModel { PatientId = 1, FirstName = "Niall", LastName = "Farren", Email = "niall@email.com", TelephoneNumber = "02877741764", MobileNumber = "01234567895" });
            modelBuilder.Entity<PatientModel>().HasData(new PatientModel { PatientId = 2, FirstName = "Shane", LastName = "Millar", Email = "shane@email.com", TelephoneNumber = "028777417321", MobileNumber = "15562722374" });
            modelBuilder.Entity<PatientModel>().HasData(new PatientModel { PatientId = 3, FirstName = "Oran", LastName = "Armstrong", Email = "oran@email.com", TelephoneNumber = "028777782616", MobileNumber = "7475871" });
            modelBuilder.Entity<PatientModel>().HasData(new PatientModel { PatientId = 4, FirstName = "Eoin", LastName = "Campbell", Email = "eoin@email.com", TelephoneNumber = "02877741764", MobileNumber = "74477474" });
            modelBuilder.Entity<PatientModel>().HasData(new PatientModel { PatientId = 5, FirstName = "Molly", LastName = "Carton", Email = "molly@email.com", TelephoneNumber = "02877711889", MobileNumber = "34976643122" });
            modelBuilder.Entity<PatientModel>().HasData(new PatientModel { PatientId = 6, FirstName = "Elaine", LastName = "Hampson", Email = "elaine@email.com", TelephoneNumber = "0287712313", MobileNumber = "0279954242" });

            //seed practices
            modelBuilder.Entity<PractitionerModel>().HasData(new PractitionerModel { PractitionerId = 1, PractitionerName = "Dentist" });
            modelBuilder.Entity<PractitionerModel>().HasData(new PractitionerModel { PractitionerId = 2, PractitionerName = "Physiotherapist" });
            modelBuilder.Entity<PractitionerModel>().HasData(new PractitionerModel { PractitionerId = 3, PractitionerName = "General Practitioner" });

            //seed appointments
            modelBuilder.Entity<AppointmentModel>().HasData(new AppointmentModel { AppointmentId = 1, PatientId = 1, AppointmentDateTime = DateTime.Now, PractitionerId = 1 });
            modelBuilder.Entity<AppointmentModel>().HasData(new AppointmentModel { AppointmentId = 2, PatientId = 1, AppointmentDateTime = DateTime.Now, PractitionerId = 2 });
            modelBuilder.Entity<AppointmentModel>().HasData(new AppointmentModel { AppointmentId = 3, PatientId = 1, AppointmentDateTime = DateTime.Now, PractitionerId = 3 });

            modelBuilder.Entity<AppointmentModel>().HasData(new AppointmentModel { AppointmentId = 4, PatientId = 2, AppointmentDateTime = DateTime.Now, PractitionerId = 2 });
            modelBuilder.Entity<AppointmentModel>().HasData(new AppointmentModel { AppointmentId = 5, PatientId = 2, AppointmentDateTime = DateTime.Now, PractitionerId = 2 });
            modelBuilder.Entity<AppointmentModel>().HasData(new AppointmentModel { AppointmentId = 6, PatientId = 4, AppointmentDateTime = DateTime.Now, PractitionerId = 3 });

        }

    }
}
