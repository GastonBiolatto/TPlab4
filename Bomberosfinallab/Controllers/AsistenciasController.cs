using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bomberosfinallab.Repos;
using Bomberosfinallab.Models;

namespace Bomberosfinallab.Controllers
{
    public class AsistenciasController : Controller
    {
        private readonly BomberosContext _context;

        public AsistenciasController(BomberosContext context)
        {
            _context = context;
        }

        // GET: Asistencias
        public async Task<IActionResult> Index()
        {
            var bomberosContext = _context.Asistencias.Include(a => a.CuerpoActivo);
            return View(await bomberosContext.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // GET: Asistencias/Create
        public IActionResult Create()
        {
            ViewData["CuerpoActivoRefId"] = new SelectList(_context.CuerpoActivos, "Id", "Nro");
            return View();
        }

        // POST: Asistencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContAsistencia,CuerpoActivoRefId")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CuerpoActivoRefId"] = new SelectList(_context.CuerpoActivos, "Id", "Nro", asistencia.CuerpoActivoRefId);
            return View(asistencia);
        }

         //GET: Asistencias/Edit/5
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
            ViewData["CuerpoActivoRefId"] = new SelectList(_context.CuerpoActivos, "Id", "Nro", asistencia.CuerpoActivoRefId);
            return View(asistencia);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContAsistencia,CuerpoActivoRefId")] Asistencia asistencia)
        {
            if (id != asistencia.Id)
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
                    if (!AsistenciaExists(asistencia.Id))
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
            ViewData["CuerpoActivoRefId"] = new SelectList(_context.CuerpoActivos, "Id", "Nro", asistencia.CuerpoActivoRefId);
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
                return Problem("Entity set 'BomberosContext.Asistencias'  is null.");
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
          return (_context.Asistencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
