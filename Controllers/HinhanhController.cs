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
    public class HinhanhController : Controller
    {
        private readonly acomptec_dulichTHContext _context = new acomptec_dulichTHContext ();
        // GET: Hinhanh
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hinhanh.ToListAsync());
        }

        // GET: Hinhanh/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhanh = await _context.Hinhanh
                .FirstOrDefaultAsync(m => m.HaMa == id);
            if (hinhanh == null)
            {
                return NotFound();
            }

            return View(hinhanh);
        }

        // GET: Hinhanh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hinhanh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HaMa,HaTen,HaUrl")] Hinhanh hinhanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hinhanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hinhanh);
        }

        // GET: Hinhanh/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhanh = await _context.Hinhanh.FindAsync(id);
            if (hinhanh == null)
            {
                return NotFound();
            }
            return View(hinhanh);
        }

        // POST: Hinhanh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HaMa,HaTen,HaUrl")] Hinhanh hinhanh)
        {
            if (id != hinhanh.HaMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hinhanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HinhanhExists(hinhanh.HaMa))
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
            return View(hinhanh);
        }

        // GET: Hinhanh/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinhanh = await _context.Hinhanh
                .FirstOrDefaultAsync(m => m.HaMa == id);
            if (hinhanh == null)
            {
                return NotFound();
            }

            return View(hinhanh);
        }

        // POST: Hinhanh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hinhanh = await _context.Hinhanh.FindAsync(id);
            _context.Hinhanh.Remove(hinhanh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HinhanhExists(string id)
        {
            return _context.Hinhanh.Any(e => e.HaMa == id);
        }
    }
}
