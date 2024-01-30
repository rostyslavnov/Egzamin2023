using Microsoft.AspNetCore.Mvc;

namespace Egzamin2023.Controllers;

public class ExamController: Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }
}