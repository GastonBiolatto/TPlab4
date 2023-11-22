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
    public class CuerpoActivosController : Controller
    {
        private readonly TPlab4Context _context;

        public CuerpoActivosController(TPlab4Context context)
        {
            _context = context;
        }

        // GET: CuerpoActivos
        public async Task<IActionResult> Index()
        {
              return _context.CuerpoActivo != null ? 
                          View(await _context.CuerpoActivo.ToListAsync()) :
                          Problem("Entity set 'TPlab4Context.CuerpoActivo'  is null.");
        }

        // GET: CuerpoActivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CuerpoActivo == null)
            {
                return NotFound();
            }

            var cuerpoActivo = await _context.CuerpoActivo
                .FirstOrDefaultAsync(m => m.IDCuerpoActivo == id);
            if (cuerpoActivo == null)
            {
                return NotFound();
            }

            return View(cuerpoActivo);
        }

        // GET: CuerpoActivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CuerpoActivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCuerpoActivo,Nombre,Apellido,DNI,Direccion,IdDepartamento")] CuerpoActivo cuerpoActivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuerpoActivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuerpoActivo);
        }

        // GET: CuerpoActivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CuerpoActivo == null)
            {
                return NotFound();
            }

            var cuerpoActivo = await _context.CuerpoActivo.FindAsync(id);
            if (cuerpoActivo == null)
            {
                return NotFound();
            }
            return View(cuerpoActivo);
        }

        // POST: CuerpoActivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDCuerpoActivo,Nombre,Apellido,DNI,Direccion,IdDepartamento")] CuerpoActivo cuerpoActivo)
        {
            if (id != cuerpoActivo.IDCuerpoActivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuerpoActivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuerpoActivoExists(cuerpoActivo.IDCuerpoActivo))
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
            return View(cuerpoActivo);
        }

        // GET: CuerpoActivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CuerpoActivo == null)
            {
                return NotFound();
            }

            var cuerpoActivo = await _context.CuerpoActivo
                .FirstOrDefaultAsync(m => m.IDCuerpoActivo == id);
            if (cuerpoActivo == null)
            {
                return NotFound();
            }

            return View(cuerpoActivo);
        }

        // POST: CuerpoActivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CuerpoActivo == null)
            {
                return Problem("Entity set 'TPlab4Context.CuerpoActivo'  is null.");
            }
            var cuerpoActivo = await _context.CuerpoActivo.FindAsync(id);
            if (cuerpoActivo != null)
            {
                _context.CuerpoActivo.Remove(cuerpoActivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuerpoActivoExists(int id)
        {
          return (_context.CuerpoActivo?.Any(e => e.IDCuerpoActivo == id)).GetValueOrDefault();
        }
    }
}
