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
    public class EquipamientoesController : Controller
    {
        private readonly TPlab4Context _context;

        public EquipamientoesController(TPlab4Context context)
        {
            _context = context;
        }

        // GET: Equipamientoes
        public async Task<IActionResult> Index()
        {
            var tPlab4Context = _context.Equipamientos.Include(e => e.Departamento);
            return View(await tPlab4Context.ToListAsync());
        }

        // GET: Equipamientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipamientos == null)
            {
                return NotFound();
            }

            var equipamiento = await _context.Equipamientos
                .Include(e => e.Departamento)
                .FirstOrDefaultAsync(m => m.IDEquipamiento == id);
            if (equipamiento == null)
            {
                return NotFound();
            }

            return View(equipamiento);
        }

        // GET: Equipamientoes/Create
        public IActionResult Create()
        {
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento");
            return View();
        }

        // POST: Equipamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDEquipamiento,Nombre,Cantidad,Ubicacion,FechaRevicion,IdDepartamento")] Equipamiento equipamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", equipamiento.IdDepartamento);
            return View(equipamiento);
        }

        // GET: Equipamientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipamientos == null)
            {
                return NotFound();
            }

            var equipamiento = await _context.Equipamientos.FindAsync(id);
            if (equipamiento == null)
            {
                return NotFound();
            }
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", equipamiento.IdDepartamento);
            return View(equipamiento);
        }

        // POST: Equipamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDEquipamiento,Nombre,Cantidad,Ubicacion,FechaRevicion,IdDepartamento")] Equipamiento equipamiento)
        {
            if (id != equipamiento.IDEquipamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipamientoExists(equipamiento.IDEquipamiento))
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
            ViewData["IdDepartamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "IdDepartamento", equipamiento.IdDepartamento);
            return View(equipamiento);
        }

        // GET: Equipamientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipamientos == null)
            {
                return NotFound();
            }

            var equipamiento = await _context.Equipamientos
                .Include(e => e.Departamento)
                .FirstOrDefaultAsync(m => m.IDEquipamiento == id);
            if (equipamiento == null)
            {
                return NotFound();
            }

            return View(equipamiento);
        }

        // POST: Equipamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipamientos == null)
            {
                return Problem("Entity set 'TPlab4Context.Equipamientos'  is null.");
            }
            var equipamiento = await _context.Equipamientos.FindAsync(id);
            if (equipamiento != null)
            {
                _context.Equipamientos.Remove(equipamiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipamientoExists(int id)
        {
          return (_context.Equipamientos?.Any(e => e.IDEquipamiento == id)).GetValueOrDefault();
        }
    }
}
