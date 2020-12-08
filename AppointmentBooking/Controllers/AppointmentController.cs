using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using AppointmentBooking.Enums;
using AppointmentBooking.Filters;
using AppointmentBooking.Models;
using AppointmentBooking.Models.DTO;
using AppointmentBooking.Repository;
using AppointmentBooking.ModelValidators;

namespace AppointmentBooking.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IPractitionerRepository _practitionerRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IModelValidator<AppointmentModel> _validator;

        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentRepository appointmentRepository, 
            IPractitionerRepository practitionerRepository, IPatientRepository patientRepository, IUserRepository userRepository, IModelValidator<AppointmentModel> validator)
        {
            _logger = logger;
            _appointmentRepository = appointmentRepository;
            _practitionerRepository = practitionerRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _validator = validator;
        }

        [ValidateAuthorizationFilter(task = Tasks.ViewAppointments)]
        public IActionResult ViewAppointments()
        {
            var viewList = BuildViewAppointmentModel();
            return View(viewList);
        }

        [ValidateAuthorizationFilter(task = Tasks.CreateAppointments)]
        public IActionResult CreateAppointment()
        {
            ViewData["Patients"] = _patientRepository.GetAll();
            ViewData["Practices"] = _practitionerRepository.GetAll();
            return View("CreateAppointment");
        }

        [ValidateAuthorizationFilter(task = Tasks.EditAppointments)]
        public IActionResult EditAppointment(int id)
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            ViewData["Patients"] = _patientRepository.GetAll();
            ViewData["Practices"] = _practitionerRepository.GetAll();
            return View(appointment);
        }

        [ValidateAuthorizationFilter(task = Tasks.CreateAppointments)]
        [HttpPost]
        public IActionResult InsertAppointment(AppointmentModel appointment)
        {
            if (appointment != null && ModelState.IsValid)
            {
                if (_validator.Validate(appointment))
                {
                    _appointmentRepository.Insert(appointment);
                    _appointmentRepository.Save();

                    return RedirectToAction("ViewAppointments", "Appointment");
                }
            }
            return BadRequest(ModelState); 
        }

        [ValidateAuthorizationFilter(task = Tasks.EditAppointments)]
        [HttpPost]
        public IActionResult UpdateAppointment(AppointmentModel appointment)
        {
            if (appointment != null && ModelState.IsValid)
            {
                if (_validator.Validate(appointment))
                {
                    _appointmentRepository.Update(appointment);
                    _appointmentRepository.Save();

                    return RedirectToAction("ViewAppointments", "Appointment");
                }
            }
            return BadRequest(ModelState);
        }

        [ValidateAuthorizationFilter(task = Tasks.DeleteAppointments)]
        public ActionResult DeleteAppointment(int id)
        {
            _appointmentRepository.Delete(id);
            _appointmentRepository.Save();

            return RedirectToAction("ViewAppointments", "Appointment");
        }

        public List<AppointmentViewDTO> BuildViewAppointmentModel()
        {
            List<AppointmentViewDTO> appointmentList = new List<AppointmentViewDTO>();
            var appointments = _appointmentRepository.GetAll();
            foreach (var appointment in appointments)
            {
                AppointmentViewDTO appointmentDto = new AppointmentViewDTO();

                var practitionerInfo = _practitionerRepository.GetById(appointment.PractitionerId);
                var patientInfo = _patientRepository.GetById(appointment.PatientId);


                appointmentDto.AppointmentId = appointment.AppointmentId;
                appointmentDto.AppointmentDateTime = appointment.AppointmentDateTime;
                appointmentDto.PracticeName = practitionerInfo.PractitionerName;
                appointmentDto.PatientFirstName = patientInfo.FirstName;
                appointmentDto.PatientLastName = patientInfo.LastName;
                appointmentDto.PatientEmail = patientInfo.Email;
                appointmentDto.PatientTelNo = patientInfo.TelephoneNumber;
                appointmentList.Add(appointmentDto);
            }
            return appointmentList;
        }

        [ValidateAuthorizationFilter(task = Tasks.ViewParctitionerPatients)]
        public IActionResult ListMyPatients()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return LocalRedirect("/Home/Login?error=2");
            }

            var userId = HttpContext.Session.GetInt32("UserId");
           
            var userObj = _userRepository.GetById(userId);

            var appointments = _appointmentRepository.GetAppointmentsByPractitionerId(userObj.PractitionerId);

            List<PatientModel> patients = new List<PatientModel>();
            foreach(var appointment in appointments)
            {
                var patient = _patientRepository.GetById(appointment.PatientId);
                if(!patients.Contains(patient))
                {
                    patients.Add(patient);
                }
             }

            return View(patients);
        }

        [ValidateAuthorizationFilter(task = Tasks.ViewParctitionerAppointments)]
        public IActionResult ListMyAppointments()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return LocalRedirect("/Home/Login?error=2");
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            var userObj = _userRepository.GetById(userId);

            var appointments = _appointmentRepository.GetAppointmentsByPractitionerId(userObj.PractitionerId);

            List<ViewPatientHistoryDTO> patientsDetails = new List<ViewPatientHistoryDTO>();
            foreach (var appointment in appointments)
            {
                var patient = _patientRepository.GetById(appointment.PatientId);
                ViewPatientHistoryDTO appointmentDto = new ViewPatientHistoryDTO();
                appointmentDto.Patient = patient;
                appointmentDto.AppointmentDateTime = appointment.AppointmentDateTime;
                appointmentDto.AppointmentId = appointment.AppointmentId;

                patientsDetails.Add(appointmentDto);
            }
            return View(patientsDetails);
        }

        [ValidateAuthorizationFilter(task = Tasks.ViewPatientHistory)]
        public IActionResult ViewPatientHistory(int patientId)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return LocalRedirect("/Home/Login?error=2");
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            var userObj = _userRepository.GetById(userId);

            var appointments = _appointmentRepository.GetAppointmentsByPractitionerIdAndPatientId(userObj.PractitionerId, patientId);

            List<ViewPatientHistoryDTO> patientsDetails = new List<ViewPatientHistoryDTO>();
            foreach (var appointment in appointments)
            {
                var patient = _patientRepository.GetById(appointment.PatientId);
                ViewPatientHistoryDTO appointmentDto = new ViewPatientHistoryDTO();
                appointmentDto.Patient = patient;
                appointmentDto.AppointmentDateTime = appointment.AppointmentDateTime;
                appointmentDto.AppointmentId = appointment.AppointmentId;

                patientsDetails.Add(appointmentDto);
            }

            return View(patientsDetails);
        }
    }
}
