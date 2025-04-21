
using Microsoft.AspNetCore.Mvc;

namespace _1_Controle_Financeiro.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
