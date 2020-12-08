using AppointmentBooking.Filters;
using AppointmentBooking.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AppointmentBooking.Enums;
using AppointmentBooking.Models;
using AppointmentBooking.ModelValidators;

namespace AppointmentBooking.Controllers
{
    [Authorize]
    public class PatientController:Controller
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientRepository _patientRepository;
        private readonly IModelValidator<PatientModel> _validator;

        public PatientController(ILogger<PatientController> logger, IPatientRepository patientRepository, IModelValidator<PatientModel> validator)
        {
            _logger = logger;
            _patientRepository = patientRepository;
            _validator = validator;
        }
        
        [ValidateAuthorizationFilter(task = Tasks.ViewPatients)]
        public IActionResult Index()
        {
            var patients = _patientRepository.GetAll();
            return View(patients);
        }

        [ValidateAuthorizationFilter(task = Tasks.CreatePatients)]
        public IActionResult CreatePatient()
        {
            return View();
        }

        [ValidateAuthorizationFilter(task = Tasks.EditPatients)]
        public IActionResult EditPatient(int id)
        {
            var patient = _patientRepository.GetById(id);
            if(patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        public ActionResult InsertPatient(PatientModel patient)
        {
            if(patient != null && ModelState.IsValid)
            {
                if (_validator.Validate(patient))
                {
                    _patientRepository.Insert(patient);
                    _patientRepository.Save();

                    return RedirectToAction("Index", "Patient");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public ActionResult UpdatePatient(PatientModel patient)
        {
            if (patient != null && ModelState.IsValid)
            {
                if (_validator.Validate(patient))
                {
                    _patientRepository.Update(patient);
                    _patientRepository.Save();

                    return RedirectToAction("Index", "Patient");
                }
            }
            return BadRequest(ModelState);
        }

        public ActionResult DeletePatient(int id)
        {
            _patientRepository.Delete(id);
            _patientRepository.Save();

            return RedirectToAction("Index", "Patient");
        }
    }
}
