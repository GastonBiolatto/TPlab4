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
    public class AsistenciasController : Controller
    {
        private readonly TPlab4Context _context;

        public AsistenciasController(TPlab4Context context)
        {
            _context = context;
        }

        // GET: Asistencias
        public async Task<IActionResult> Index()
        {
            var tPlab4Context = _context.Asistencias.Include(a => a.CuerpoActivo);
            return View(await tPlab4Context.ToListAsync());
        }

        // GET: Asistencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asistencias == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias
                .Include(a => a.CuerpoActivo)
                .FirstOrDefaultAsync(m => m.IIDAsistencia == id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // GET: Asistencias/Create
        public IActionResult Create()
        {
            ViewData["IDCuerpoActivo"] = new SelectList(_context.CuerpoActivo, "IDCuerpoActivo", "IDCuerpoActivo");
            return View();
        }

        // POST: Asistencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IIDAsistencia,ContAsistencia,IDCuerpoActivo")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCuerpoActivo"] = new SelectList(_context.CuerpoActivo, "IDCuerpoActivo", "IDCuerpoActivo", asistencia.IDCuerpoActivo);
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asistencias == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }
            ViewData["IDCuerpoActivo"] = new SelectList(_context.CuerpoActivo, "IDCuerpoActivo", "IDCuerpoActivo", asistencia.IDCuerpoActivo);
            return View(asistencia);
        }

        // POST: Asistencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IIDAsistencia,ContAsistencia,IDCuerpoActivo")] Asistencia asistencia)
        {
            if (id != asistencia.IIDAsistencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaExists(asistencia.IIDAsistencia))
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
            ViewData["IDCuerpoActivo"] = new SelectList(_context.CuerpoActivo, "IDCuerpoActivo", "IDCuerpoActivo", asistencia.IDCuerpoActivo);
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asistencias == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias
                .Include(a => a.CuerpoActivo)
                .FirstOrDefaultAsync(m => m.IIDAsistencia == id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asistencias == null)
            {
                return Problem("Entity set 'TPlab4Context.Asistencias'  is null.");
            }
            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia != null)
            {
                _context.Asistencias.Remove(asistencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaExists(int id)
        {
          return (_context.Asistencias?.Any(e => e.IIDAsistencia == id)).GetValueOrDefault();
        }
    }
}
