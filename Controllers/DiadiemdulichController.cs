using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn3.Models;

namespace DoAn3.Controllers
{
    public class DiadiemdulichController : Controller
    {
        private readonly acomptec_dulichTHContext _context = new acomptec_dulichTHContext ();

        // GET: Diadiemdulich
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diadiemdulich.ToListAsync());
        }

        // GET: Diadiemdulich/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diadiemdulich = await _context.Diadiemdulich
                .FirstOrDefaultAsync(m => m.DddlMa == id);
            if (diadiemdulich == null)
            {
                return NotFound();
            }

            return View(diadiemdulich);
        }

        // GET: Diadiemdulich/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diadiemdulich/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DddlMa,DddlTen")] Diadiemdulich diadiemdulich)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diadiemdulich);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diadiemdulich);
        }

        // GET: Diadiemdulich/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diadiemdulich = await _context.Diadiemdulich.FindAsync(id);
            if (diadiemdulich == null)
            {
                return NotFound();
            }
            return View(diadiemdulich);
        }

        // POST: Diadiemdulich/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DddlMa,DddlTen")] Diadiemdulich diadiemdulich)
        {
            if (id != diadiemdulich.DddlMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diadiemdulich);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiadiemdulichExists(diadiemdulich.DddlMa))
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
            return View(diadiemdulich);
        }

        // GET: Diadiemdulich/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diadiemdulich = await _context.Diadiemdulich
                .FirstOrDefaultAsync(m => m.DddlMa == id);
            if (diadiemdulich == null)
            {
                return NotFound();
            }

            return View(diadiemdulich);
        }

        // POST: Diadiemdulich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var diadiemdulich = await _context.Diadiemdulich.FindAsync(id);
            _context.Diadiemdulich.Remove(diadiemdulich);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiadiemdulichExists(string id)
        {
            return _context.Diadiemdulich.Any(e => e.DddlMa == id);
        }
    }
}
