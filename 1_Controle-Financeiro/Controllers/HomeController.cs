using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _1_Controle_Financeiro.Models;

namespace _1_Controle_Financeiro.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
