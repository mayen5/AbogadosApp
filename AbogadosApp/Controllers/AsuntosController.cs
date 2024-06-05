using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbogadosApp.Data;
using AbogadosApp.Models;
using AbogadosApp.ViewModels;

namespace AbogadosApp.Controllers
{
    public class AsuntosController : Controller
    {
        private readonly AbogadosContext _context;

        public AsuntosController(AbogadosContext context)
        {
            _context = context;
        }

        // GET: Asuntos
        public async Task<IActionResult> Index(int id)
        {
            var cliente = _context.Clientes.Find(id);
            var asuntos = _context.Asuntos.Where(a => a.IdCliente == id).ToList();

            var viewModel = new AsuntoClienteViewModel
            {
                Cliente = cliente,
                Asuntos = asuntos
            };

            return View(viewModel);
        }

        // GET: Asuntos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var cliente = _context.Clientes.Find(id); // Obtén el cliente por ID
            var asuntos = _context.Asuntos.Where(a => a.IdCliente == id).ToList(); // Obtén los asuntos del cliente

            var viewModel = new AsuntoClienteViewModel
            {
                Cliente = cliente,
                Asuntos = asuntos
            };

            return View(viewModel);
        }

        // GET: Asuntos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asuntos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descripcion,Fecha,IdCliente")] Asunto asunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asunto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asunto);
        }

        // GET: Asuntos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asuntos == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos.FindAsync(id);
            if (asunto == null)
            {
                return NotFound();
            }
            return View(asunto);
        }

        // POST: Asuntos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descripcion,Fecha,IdCliente")] Asunto asunto)
        {
            if (id != asunto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsuntoExists(asunto.ID))
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
            return View(asunto);
        }

        // GET: Asuntos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asuntos == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (asunto == null)
            {
                return NotFound();
            }

            return View(asunto);
        }

        // POST: Asuntos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asuntos == null)
            {
                return Problem("Entity set 'AbogadosContext.Asuntos'  is null.");
            }
            var asunto = await _context.Asuntos.FindAsync(id);
            if (asunto != null)
            {
                _context.Asuntos.Remove(asunto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsuntoExists(int id)
        {
          return (_context.Asuntos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
