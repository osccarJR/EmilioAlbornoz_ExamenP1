using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmilioAlbornoz_ExamenP1.Data;
using EmilioAlbornoz_ExamenP1.Models;

namespace EmilioAlbornoz_ExamenP1.Controllers
{
    public class EAPolloController : Controller
    {
        private readonly EmilioAlbornoz_ExamenP1Context _context;

        public EAPolloController(EmilioAlbornoz_ExamenP1Context context)
        {
            _context = context;
        }

        // GET: EAPollo
        public async Task<IActionResult> Index()
        {
            return View(await _context.EAPollo.ToListAsync());
        }

        // GET: EAPollo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eAPollo = await _context.EAPollo
                .FirstOrDefaultAsync(m => m.EA_PolloId == id);
            if (eAPollo == null)
            {
                return NotFound();
            }

            return View(eAPollo);
        }

        // GET: EAPollo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EAPollo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EA_PolloId,EA_Nombre,EA_Piezas,EA_FechadeProduccion,EA_Price,EA_IncluyeSalsa")] EAPollo eAPollo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eAPollo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eAPollo);
        }

        // GET: EAPollo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eAPollo = await _context.EAPollo.FindAsync(id);
            if (eAPollo == null)
            {
                return NotFound();
            }
            return View(eAPollo);
        }

        // POST: EAPollo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EA_PolloId,EA_Nombre,EA_Piezas,EA_FechadeProduccion,EA_Price,EA_IncluyeSalsa")] EAPollo eAPollo)
        {
            if (id != eAPollo.EA_PolloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eAPollo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EAPolloExists(eAPollo.EA_PolloId))
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
            return View(eAPollo);
        }

        // GET: EAPollo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eAPollo = await _context.EAPollo
                .FirstOrDefaultAsync(m => m.EA_PolloId == id);
            if (eAPollo == null)
            {
                return NotFound();
            }

            return View(eAPollo);
        }

        // POST: EAPollo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eAPollo = await _context.EAPollo.FindAsync(id);
            if (eAPollo != null)
            {
                _context.EAPollo.Remove(eAPollo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EAPolloExists(int id)
        {
            return _context.EAPollo.Any(e => e.EA_PolloId == id);
        }
    }
}
