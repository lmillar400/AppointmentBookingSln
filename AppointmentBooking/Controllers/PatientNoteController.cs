using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AppointmentBooking.Enums;
using AppointmentBooking.Filters;
using AppointmentBooking.Repository;
using AppointmentBooking.Models;
using AppointmentBooking.Models.DTO;
using AppointmentBooking.ModelValidators;

namespace AppointmentBooking.Controllers
{
    [Authorize]
    public class PatientNoteController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IPatientNoteRepository _patientNoteRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IModelValidator<PatientNoteModel> _validatorRepository;

        public PatientNoteController(IUserRepository userRepo, IPatientNoteRepository patientNoteRepository, IPatientRepository patientRepository, IModelValidator<PatientNoteModel> validator)
        {
            _userRepository = userRepo;
            _patientNoteRepository = patientNoteRepository;
            _patientRepository = patientRepository;
            _validatorRepository = validator;
        }

        [ValidateAuthorizationFilter(task = Tasks.ViewPatientHistory)]
        public IActionResult ViewPatientNotes(int patientId)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return LocalRedirect("/Home/Login?error=2");
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            var userObj = _userRepository.GetById(userId);

            var notes = _patientNoteRepository.GetPatientNotesByPatientIdAndPractitionerId(patientId, userObj.PractitionerId);

            var patientDetails = _patientRepository.GetById(patientId);

            ViewPatientNotesDTO patientNotesDto = new ViewPatientNotesDTO();
            patientNotesDto.PatientNotes = notes;
            patientNotesDto.PatientDetails = patientDetails;

            return View(patientNotesDto);
        }
       
        [ValidateAuthorizationFilter(task = Tasks.CreatePatientNotes)]
        public IActionResult CreatePatientNote(int patientId)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return LocalRedirect("/Home/Login?error=2");
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            var userObj = _userRepository.GetById(userId);

            PatientNoteModel patientNote = new PatientNoteModel();
            patientNote.PatientId = patientId;
            patientNote.PractitionerId = userObj.PractitionerId;

            return View(patientNote);
        }

        [ValidateAuthorizationFilter(task = Tasks.CreatePatientNotes)]
        [HttpPost]
        public IActionResult InsertPatientNote(PatientNoteModel note)
        {
            if (note!= null && ModelState.IsValid)
            {
                note.CreationDate = DateTime.Now;
                if(_validatorRepository.Validate(note))
                {
                    _patientNoteRepository.Insert(note);
                    _patientNoteRepository.Save();
                    return RedirectToAction("ViewPatientNotes", "PatientNote", new { patientId = note.PatientId });
                }
            }
            return BadRequest(ModelState);
        }
    }
}
