using ChamadosSAAS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChamadosSAAS.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        // Protótipo de front: ainda não há autenticação.
        return View(model);
    }
}
