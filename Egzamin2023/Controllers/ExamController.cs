using Egzamin2023.Models;
using Egzamin2023.Services;
using Microsoft.AspNetCore.Mvc;

namespace Egzamin2023.Controllers;

public class ExamController: Controller
{
    private readonly NoteService _service;
    private readonly IDateProvider _dateProvider;

    public ExamController(NoteService service, IDateProvider dateProvider)
    {
        _service = service;
        _dateProvider = dateProvider;
    }

    public IActionResult Index()
    {
        var notes = _service.GetAll();
        return View(notes);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Note note)
    {
        if (note.Deadline < DateTime.Now)
        {
            ModelState.AddModelError("Deadline", "Data ważności!"); 
        }
        if (ModelState.IsValid)
        {
            _service.Add(note);
            return View("Index", _service.GetAll());
        }
        return View();
    }
    
    public IActionResult Details(string id)
    {
        var note = _service.GetById(id);
        if (note is null)
        {
            return BadRequest("Brak notatki o takim id");
        }
        return View(note);
    }
}