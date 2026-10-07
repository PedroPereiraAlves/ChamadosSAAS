using System.Diagnostics;
using ChamadosSAAS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChamadosSAAS.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
