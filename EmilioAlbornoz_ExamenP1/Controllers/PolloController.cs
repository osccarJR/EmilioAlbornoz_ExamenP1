using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmilioAlbornozBurger.Models;
using EmilioAlbornoz_ExamenP1.Data;

namespace EmilioAlbornoz_ExamenP1.Controllers
{
    public class PolloController : Controller
    {
        private readonly EmilioAlbornoz_ExamenP1Context _context;

        public PolloController(EmilioAlbornoz_ExamenP1Context context)
        {
            _context = context;
        }

        // GET: Pollo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pollo.ToListAsync());
        }

        // GET: Pollo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollo = await _context.Pollo
                .FirstOrDefaultAsync(m => m.EA_PolloId == id);
            if (pollo == null)
            {
                return NotFound();
            }

            return View(pollo);
        }

        // GET: Pollo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pollo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EA_PolloId,EA_Nombre,EA_Piezas,EA_FechadeProduccion,EA_Price,EA_IncluyeSalsa")] Pollo pollo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pollo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pollo);
        }

        // GET: Pollo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollo = await _context.Pollo.FindAsync(id);
            if (pollo == null)
            {
                return NotFound();
            }
            return View(pollo);
        }

        // POST: Pollo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EA_PolloId,EA_Nombre,EA_Piezas,EA_FechadeProduccion,EA_Price,EA_IncluyeSalsa")] Pollo pollo)
        {
            if (id != pollo.EA_PolloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pollo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolloExists(pollo.EA_PolloId))
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
            return View(pollo);
        }

        // GET: Pollo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollo = await _context.Pollo
                .FirstOrDefaultAsync(m => m.EA_PolloId == id);
            if (pollo == null)
            {
                return NotFound();
            }

            return View(pollo);
        }

        // POST: Pollo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pollo = await _context.Pollo.FindAsync(id);
            if (pollo != null)
            {
                _context.Pollo.Remove(pollo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolloExists(int id)
        {
            return _context.Pollo.Any(e => e.EA_PolloId == id);
        }
    }
}
