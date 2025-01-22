// Novytskyi Rostyslav 15204
using Microsoft.AspNetCore.Mvc;
using Egzamin2023.Models;
using Egzamin2023.Services;

namespace Egzamin2023.Controllers
{
    public class ExamController : Controller
    {
        private readonly NoteService _noteService;
        private readonly IDateProvider _dateProvider;

        public ExamController(NoteService noteService, IDateProvider dateProvider)
        {
            _noteService = noteService;
            _dateProvider = dateProvider;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                var currentDate = _dateProvider.CurrentDate;

                if (note.Deadline <= currentDate.AddHours(1))
                {
                    ModelState.AddModelError(nameof(note.Deadline), "Czas ważności musi być o godzinę późniejszy od bieżącego czasu!");
                    return View(note);
                }

                _noteService.Add(note);
                return RedirectToAction("Index");
            }
            return View(note);
        }
        public IActionResult Index()
        {
            var notes = _noteService.GetAll();
            return View(notes);
        }

        public IActionResult Details(string title)
        {
            var note = _noteService.GetById(title);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }
    }
}