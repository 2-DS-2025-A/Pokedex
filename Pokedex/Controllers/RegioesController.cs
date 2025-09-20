using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Data;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class RegioesController : Controller
    {
        private readonly AppDbContext _context;

        public RegioesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Regioes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regioes.ToListAsync());
        }

        // GET: Regioes/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // GET: Regioes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regioes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regiao);
        }

        // GET: Regioes/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null)
            {
                return NotFound();
            }
            return View(regiao);
        }

        // POST: Regioes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Nome")] Regiao regiao)
        {
            if (id != regiao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegiaoExists(regiao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(regiao);
        }

        // GET: Regioes/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // POST: Regioes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao != null)
            {
                _context.Regioes.Remove(regiao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegiaoExists(uint id)
        {
            return _context.Regioes.Any(e => e.Id == id);
        }
    }
}
