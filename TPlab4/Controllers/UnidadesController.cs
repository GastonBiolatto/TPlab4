using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPlab4.Repos;
using tpfinal.Models;

namespace TPlab4.Controllers
{
    public class UnidadesController : Controller
    {
        private readonly TPlab4Context _context;

        public UnidadesController(TPlab4Context context)
        {
            _context = context;
        }

        // GET: Unidades
        public async Task<IActionResult> Index()
        {
              return _context.Unidades != null ? 
                          View(await _context.Unidades.ToListAsync()) :
                          Problem("Entity set 'TPlab4Context.Unidades'  is null.");
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidades = await _context.Unidades
                .FirstOrDefaultAsync(m => m.IDUnidades == id);
            if (unidades == null)
            {
                return NotFound();
            }

            return View(unidades);
        }

        // GET: Unidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDUnidades,Numero,Tipo,FechaRevicion")] Unidades unidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidades);
        }

        // GET: Unidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidades = await _context.Unidades.FindAsync(id);
            if (unidades == null)
            {
                return NotFound();
            }
            return View(unidades);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDUnidades,Numero,Tipo,FechaRevicion")] Unidades unidades)
        {
            if (id != unidades.IDUnidades)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadesExists(unidades.IDUnidades))
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
            return View(unidades);
        }

        // GET: Unidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidades = await _context.Unidades
                .FirstOrDefaultAsync(m => m.IDUnidades == id);
            if (unidades == null)
            {
                return NotFound();
            }

            return View(unidades);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unidades == null)
            {
                return Problem("Entity set 'TPlab4Context.Unidades'  is null.");
            }
            var unidades = await _context.Unidades.FindAsync(id);
            if (unidades != null)
            {
                _context.Unidades.Remove(unidades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadesExists(int id)
        {
          return (_context.Unidades?.Any(e => e.IDUnidades == id)).GetValueOrDefault();
        }
    }
}
