using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(
        ILogger<HomeController> logger,
        AppDbContext db
    )
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        var pokemons = _db.Pokemons
            .Include(p => p.Regiao)
            .Include(p => p.Genero)
            .Include(p => p.Tipos)
            .ThenInclude(t => t.Tipo)
            .ToList();
        return View(pokemons);
    }

    public IActionResult Details(uint id)
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
