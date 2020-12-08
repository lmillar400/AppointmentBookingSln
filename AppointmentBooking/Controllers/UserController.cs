using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentBooking.Enums;
using AppointmentBooking.Filters;
using AppointmentBooking.Helpers;
using AppointmentBooking.Models;
using AppointmentBooking.ModelValidators;
using AppointmentBooking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppointmentBooking.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPractitionerRepository _practionerRepository;
        private readonly ICryptographyHelper _cryptographyHelper;
        private readonly IModelValidator<UserModel> _validator;

        public UserController(ILogger<UserController> logger, IUserRoleRepository userRoleRepository,
            IUserRepository userRepository, IPractitionerRepository practitionerRepository, ICryptographyHelper cryptographyHelper, IModelValidator<UserModel> validator)
        {
            _logger = logger;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _practionerRepository = practitionerRepository;
            _cryptographyHelper = cryptographyHelper;
            _validator = validator;
        }
        
        [ValidateAuthorizationFilter(task = Tasks.ViewUsers)]
        public IActionResult ViewUsers()
        {
            var users = _userRepository.GetAll();
            ViewData["UserRoles"] = _userRoleRepository.GetAll();
            ViewData["Practitioners"] = _practionerRepository.GetAll();
            return View(users);
        }

        [ValidateAuthorizationFilter(task = Tasks.CreateUsers)]
        public IActionResult CreateUser()
        {
            ViewData["UserRoles"] = _userRoleRepository.GetAll();
            ViewData["Practitioners"] = _practionerRepository.GetAll();
            return View("CreateUser");
        }

        [ValidateAuthorizationFilter(task = Tasks.EditUsers)]
        public IActionResult EditUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserRoles"] = _userRoleRepository.GetAll();
            ViewData["Practitioners"] = _practionerRepository.GetAll();
            return View(user);
        }

        [HttpPost]
        public IActionResult InsertUser(UserModel user)
        {
            var userObj = _userRepository.GetUserByUserName(user.UserName);
            if (userObj != null)
            {
                return LocalRedirect("/User/CreateUser?error=1");
            }

            if (user != null)
            {
                var salt = _cryptographyHelper.CreateSalt();
                var hash = _cryptographyHelper.GenerateHash(user.PasswordHash, salt);

                user.PasswordHash = hash;
                user.PasswordSalt = salt;

                if(_validator.Validate(user))
                {
                    _userRepository.Insert(user);
                    _userRepository.Save();

                    return RedirectToAction("ViewUsers", "User");
                }

                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserModel user)
        {
            if (user != null)
            {
                if (_validator.Validate(user))
                {
                    _userRepository.Update(user);
                    _userRepository.Save();

                    return RedirectToAction("ViewUsers", "User");
                }
            }
            return BadRequest(ModelState);
        }

        public ActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();

            return RedirectToAction("ViewUsers", "User");
        }
    }
}
