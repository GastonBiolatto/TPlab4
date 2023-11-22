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
    public class EquipamientoesController : Controller
    {
        private readonly BomberosContext _context;

        public EquipamientoesController(BomberosContext context)
        {
            _context = context;
        }

        // GET: Equipamientoes
        public async Task<IActionResult> Index()
        {
            var bomberosContext = _context.Equipamientos.Include(e => e.Departamento);
            return View(await bomberosContext.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipamiento == null)
            {
                return NotFound();
            }

            return View(equipamiento);
        }

        // GET: Equipamientoes/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoRefId"] = new SelectList(_context.Departamentos, "Id", "Nombre");
            return View();
        }

        // POST: Equipamientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Cantidad,Ubicacion,FechaRevicion,DepartamentoRefId")] Equipamiento equipamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartamentoRefId"] = new SelectList(_context.Departamentos, "Id", "Nombre", equipamiento.DepartamentoRefId);
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
            ViewData["DepartamentoRefId"] = new SelectList(_context.Departamentos, "Id", "Nombre", equipamiento.DepartamentoRefId);
            return View(equipamiento);
        }

        // POST: Equipamientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cantidad,Ubicacion,FechaRevicion,DepartamentoRefId")] Equipamiento equipamiento)
        {
            if (id != equipamiento.Id)
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
                    if (!EquipamientoExists(equipamiento.Id))
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
            ViewData["DepartamentoRefId"] = new SelectList(_context.Departamentos, "Id", "Nombre", equipamiento.DepartamentoRefId);
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
                return Problem("Entity set 'BomberosContext.Equipamientos'  is null.");
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
          return (_context.Equipamientos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
