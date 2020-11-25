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
    public class TinhthanhController : Controller
    {
        private readonly acomptec_dulichTHContext _context = new acomptec_dulichTHContext ();

        // GET: Tinhthanh
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tinhthanh.ToListAsync());
        }

        // GET: Tinhthanh/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhthanh = await _context.Tinhthanh
                .FirstOrDefaultAsync(m => m.TtMa == id);
            if (tinhthanh == null)
            {
                return NotFound();
            }

            return View(tinhthanh);
        }

        // GET: Tinhthanh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tinhthanh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TtMa,TtTen")] Tinhthanh tinhthanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinhthanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinhthanh);
        }

        // GET: Tinhthanh/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhthanh = await _context.Tinhthanh.FindAsync(id);
            if (tinhthanh == null)
            {
                return NotFound();
            }
            return View(tinhthanh);
        }

        // POST: Tinhthanh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TtMa,TtTen")] Tinhthanh tinhthanh)
        {
            if (id != tinhthanh.TtMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinhthanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinhthanhExists(tinhthanh.TtMa))
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
            return View(tinhthanh);
        }

        // GET: Tinhthanh/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhthanh = await _context.Tinhthanh
                .FirstOrDefaultAsync(m => m.TtMa == id);
            if (tinhthanh == null)
            {
                return NotFound();
            }

            return View(tinhthanh);
        }

        // POST: Tinhthanh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tinhthanh = await _context.Tinhthanh.FindAsync(id);
            _context.Tinhthanh.Remove(tinhthanh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinhthanhExists(string id)
        {
            return _context.Tinhthanh.Any(e => e.TtMa == id);
        }
    }
}
