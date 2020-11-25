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
    public class QuantriController : Controller
    {
        private readonly acomptec_dulichTHContext _context = new acomptec_dulichTHContext ();

        // GET: Quantri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quantri.ToListAsync());
        }

        // GET: Quantri/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quantri = await _context.Quantri
                .FirstOrDefaultAsync(m => m.QtEmail == id);
            if (quantri == null)
            {
                return NotFound();
            }

            return View(quantri);
        }

        // GET: Quantri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quantri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QtEmail,QtMatkhau")] Quantri quantri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quantri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quantri);
        }

        // GET: Quantri/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quantri = await _context.Quantri.FindAsync(id);
            if (quantri == null)
            {
                return NotFound();
            }
            return View(quantri);
        }

        // POST: Quantri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("QtEmail,QtMatkhau")] Quantri quantri)
        {
            if (id != quantri.QtEmail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quantri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuantriExists(quantri.QtEmail))
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
            return View(quantri);
        }

        // GET: Quantri/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quantri = await _context.Quantri
                .FirstOrDefaultAsync(m => m.QtEmail == id);
            if (quantri == null)
            {
                return NotFound();
            }

            return View(quantri);
        }

        // POST: Quantri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quantri = await _context.Quantri.FindAsync(id);
            _context.Quantri.Remove(quantri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuantriExists(string id)
        {
            return _context.Quantri.Any(e => e.QtEmail == id);
        }
    }
}
