using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bomberosfinallab.Models;
using Bomberosfinallab.Repos;
using EnumsNET;
using ClosedXML.Excel;
using System.Data;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Bomberosfinallab.Controllers
{
    public class CuerpoActivoesController : Controller
    {
        private readonly BomberosContext _context;
        private readonly IWebHostEnvironment _HostEnvironment;
        public CuerpoActivoesController(BomberosContext context, IWebHostEnvironment hostEnvironment )
        {
            _context = context;
            _HostEnvironment = hostEnvironment;
        }


        // GET: CuerpoActivoes
        public async Task<IActionResult> Index()
        {
            var bomberosContext = _context.CuerpoActivos.Include(c => c.Departamento);
            return View(await bomberosContext.ToListAsync());
        }

        // GET: CuerpoActivoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CuerpoActivos == null)
            {
                return NotFound();
            }

            var cuerpoActivo = await _context.CuerpoActivos
                .Include(c => c.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuerpoActivo == null)
            {
                return NotFound();
            }

            return View(cuerpoActivo);
        }



        // GET: CuerpoActivoes/Create
        public IActionResult Create()
        {
            ViewData["DepartamentoRefId"] = new SelectList(_context.Departamentos, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nro,Nombre,Apellido,DNI,Direccion,DepartamentoRefId,ImageFile")] CuerpoActivo cuerpoActivo)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(cuerpoActivo.ImageFile.FileName);
                string extension = Path.GetExtension(cuerpoActivo.ImageFile.FileName);
                cuerpoActivo.ImagemBomber = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await cuerpoActivo.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(cuerpoActivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));   
            }
            ViewData["DepartamentoRefId"] = new SelectList(_context.Departamentos, "Id", "Nombre", cuerpoActivo.DepartamentoRefId);
            return View(cuerpoActivo);
        }



        // GET: CuerpoActivoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CuerpoActivos == null)
            {
                return NotFound();
            }

            var cuerpoActivo = await _context.CuerpoActivos.FindAsync(id);
            if (cuerpoActivo == null)
            {
                return NotFound();
            }
            ViewData["DepartamentoRefId"] = new SelectList(_context.Departamentos, "Id", "Nombre", cuerpoActivo.DepartamentoRefId);
            return View(cuerpoActivo);
        }

        // POST: CuerpoActivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nro,Nombre,Apellido,DNI,Direccion,DepartamentoRefId,ImagemBomber")] CuerpoActivo cuerpoActivo)
        {
            if (id != cuerpoActivo.Id)
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
                    if (!CuerpoActivoExists(cuerpoActivo.Id))
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
            ViewData["DepartamentoRefId"] = new SelectList(_context.Departamentos, "Id", "Nombre", cuerpoActivo.DepartamentoRefId);
            return View(cuerpoActivo);
        }

        // GET: CuerpoActivoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CuerpoActivos == null)
            {
                return NotFound();
            }

            var cuerpoActivo = await _context.CuerpoActivos
                .Include(c => c.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuerpoActivo == null)
            {
                return NotFound();
            }

            return View(cuerpoActivo);
        }

        // POST: CuerpoActivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CuerpoActivos == null)
            {
                return Problem("Entity set 'BomberosContext.CuerpoActivos'  is null.");
            }
            var cuerpoActivo = await _context.CuerpoActivos.FindAsync(id);
            if (cuerpoActivo != null)
            {
                _context.CuerpoActivos.Remove(cuerpoActivo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuerpoActivoExists(int id)
        {
          return (_context.CuerpoActivos?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> Exportar()
        {
            var bomberosContext = _context.CuerpoActivos.Include(c => c.Departamento);

            DataTable dt = new DataTable();
            dt.Columns.Add("Nro", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Apellido", typeof(string));
            dt.Columns.Add("DNI", typeof(int));
            dt.Columns.Add("Direccion", typeof(string));
            dt.Columns.Add("DepartamentoRefId", typeof(string));

            foreach (CuerpoActivo rp in bomberosContext)
            {
                dt.Rows.Add(new object[]
                {
                    rp.Nro,
                    rp.Nombre,
                    rp.Apellido,
                    rp.DNI,
                    rp.Direccion,
                    rp.DepartamentoRefId
                });
            }
            dt.TableName = "datos";

            using (XLWorkbook Wb = new XLWorkbook())
            {
                Wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    Wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Nombre" + ".xlsx");
                }
            }
        }
    }
}
