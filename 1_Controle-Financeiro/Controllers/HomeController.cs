using _1_Controle_Financeiro.Database;
using _1_Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace _1_Controle_Financeiro.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index(string id)
    {
        var filtros = new Filtros(id);

        ViewBag.Filtros = filtros;
        ViewBag.Categorias = _context.Categorias.ToList();
        ViewBag.Transacoes = _context.Transacoes.ToList();

        IQueryable<Financeiro> consulta = _context.Financas.Include(x => x.Transacao).Include(x => x.Categoria);

        if (filtros.TemCategoria)
        {
            consulta.Where(x => x.CategoriaId == filtros.CategoriaId);
        };

        if (filtros.TemTransacao)
        {
            consulta = consulta.Where(x => x.TransacaoId == filtros.TransacaoId);
        };

        if (filtros.TemDataOperacao)
        {
            var hoje = DateTime.Today;
            if (filtros.EPassado)
            {
                consulta = consulta.Where(x => x.DataDaOperacao < hoje);
            }

            if (filtros.EFuturo)
            {
                consulta = consulta.Where(x => x.DataDaOperacao > hoje);
            }

            if (filtros.EHoje)
            {
                consulta = consulta.Where(x => x.DataDaOperacao == hoje);
            }
        }
        var financas = consulta.OrderBy(d => d.DataDaOperacao).ToList();
        return View(financas);
    }
}
