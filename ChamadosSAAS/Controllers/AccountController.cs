using ChamadosSAAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        // Nunca devolve a senha digitada no HTML, mesmo quando a validação falha.
        ForgetPostedPassword(model);

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.StatusMessage = "A autenticação ainda não está disponível neste protótipo.";
        return View(model);
    }

    private void ForgetPostedPassword(LoginViewModel model)
    {
        model.Senha = string.Empty;
        ModelState.SetModelValue(nameof(LoginViewModel.Senha), new ValueProviderResult(string.Empty));
    }
}
