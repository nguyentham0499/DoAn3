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
    public class BaivietdulichController : Controller
    {
        private readonly acomptec_dulichTHContext _context = new acomptec_dulichTHContext ();

        // GET: Baivietdulich
        public async Task<IActionResult> Index()
        {
            var acomptec_dulichTHContext = _context.Baivietdulich.Include(b => b.BvdlEmailqtNavigation).Include(b => b.BvdlMabdgNavigation).Include(b => b.BvdlMadddlNavigation).Include(b => b.BvdlMahinhanhNavigation).Include(b => b.BvdlMattNavigation);
            return View(await acomptec_dulichTHContext.ToListAsync());
        }

        // GET: Baivietdulich/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baivietdulich = await _context.Baivietdulich
                .Include(b => b.BvdlEmailqtNavigation)
                .Include(b => b.BvdlMabdgNavigation)
                .Include(b => b.BvdlMadddlNavigation)
                .Include(b => b.BvdlMahinhanhNavigation)
                .Include(b => b.BvdlMattNavigation)
                .FirstOrDefaultAsync(m => m.BvdlMa == id);
            if (baivietdulich == null)
            {
                return NotFound();
            }

            return View(baivietdulich);
        }

        // GET: Baivietdulich/Create
        public IActionResult Create()
        {
            ViewData["BvdlEmailqt"] = new SelectList(_context.Quantri, "QtEmail", "QtEmail");
            ViewData["BvdlMabdg"] = new SelectList(_context.Baidanhgia, "BdgMa", "BdgMa");
            ViewData["BvdlMadddl"] = new SelectList(_context.Diadiemdulich, "DddlMa", "DddlTen");
            ViewData["BvdlMahinhanh"] = new SelectList(_context.Hinhanh, "HaMa", "HaTen");
            ViewData["BvdlMatt"] = new SelectList(_context.Tinhthanh, "TtMa", "TtTen");
            return View();
        }

        // POST: Baivietdulich/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BvdlMa,BvdlNoidung,BvdlLuotthich,BvdlEmailqt,BvdlMadddl,BvdlMatt,BvdlMahinhanh,BvdlMabdg")] Baivietdulich baivietdulich)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baivietdulich);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BvdlEmailqt"] = new SelectList(_context.Quantri, "QtEmail", "QtEmail", baivietdulich.BvdlEmailqt);
            ViewData["BvdlMabdg"] = new SelectList(_context.Baidanhgia, "BdgMa", "BdgMa", baivietdulich.BvdlMabdg);
            ViewData["BvdlMadddl"] = new SelectList(_context.Diadiemdulich, "DddlMa", "DddlMa", baivietdulich.BvdlMadddl);
            ViewData["BvdlMahinhanh"] = new SelectList(_context.Hinhanh, "HaMa", "HaMa", baivietdulich.BvdlMahinhanh);
            ViewData["BvdlMatt"] = new SelectList(_context.Tinhthanh, "TtMa", "TtMa", baivietdulich.BvdlMatt);
            return View(baivietdulich);
        }

        // GET: Baivietdulich/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baivietdulich = await _context.Baivietdulich.FindAsync(id);
            if (baivietdulich == null)
            {
                return NotFound();
            }
            ViewData["BvdlEmailqt"] = new SelectList(_context.Quantri, "QtEmail", "QtEmail", baivietdulich.BvdlEmailqt);
            ViewData["BvdlMabdg"] = new SelectList(_context.Baidanhgia, "BdgMa", "BdgMa", baivietdulich.BvdlMabdg);
            ViewData["BvdlMadddl"] = new SelectList(_context.Diadiemdulich, "DddlMa", "DddlMa", baivietdulich.BvdlMadddl);
            ViewData["BvdlMahinhanh"] = new SelectList(_context.Hinhanh, "HaMa", "HaMa", baivietdulich.BvdlMahinhanh);
            ViewData["BvdlMatt"] = new SelectList(_context.Tinhthanh, "TtMa", "TtMa", baivietdulich.BvdlMatt);
            return View(baivietdulich);
        }

        // POST: Baivietdulich/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BvdlMa,BvdlNoidung,BvdlLuotthich,BvdlEmailqt,BvdlMadddl,BvdlMatt,BvdlMahinhanh,BvdlMabdg")] Baivietdulich baivietdulich)
        {
            if (id != baivietdulich.BvdlMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baivietdulich);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaivietdulichExists(baivietdulich.BvdlMa))
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
            ViewData["BvdlEmailqt"] = new SelectList(_context.Quantri, "QtEmail", "QtEmail", baivietdulich.BvdlEmailqt);
            ViewData["BvdlMabdg"] = new SelectList(_context.Baidanhgia, "BdgMa", "BdgMa", baivietdulich.BvdlMabdg);
            ViewData["BvdlMadddl"] = new SelectList(_context.Diadiemdulich, "DddlMa", "DddlMa", baivietdulich.BvdlMadddl);
            ViewData["BvdlMahinhanh"] = new SelectList(_context.Hinhanh, "HaMa", "HaMa", baivietdulich.BvdlMahinhanh);
            ViewData["BvdlMatt"] = new SelectList(_context.Tinhthanh, "TtMa", "TtMa", baivietdulich.BvdlMatt);
            return View(baivietdulich);
        }

        // GET: Baivietdulich/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baivietdulich = await _context.Baivietdulich
                .Include(b => b.BvdlEmailqtNavigation)
                .Include(b => b.BvdlMabdgNavigation)
                .Include(b => b.BvdlMadddlNavigation)
                .Include(b => b.BvdlMahinhanhNavigation)
                .Include(b => b.BvdlMattNavigation)
                .FirstOrDefaultAsync(m => m.BvdlMa == id);
            if (baivietdulich == null)
            {
                return NotFound();
            }

            return View(baivietdulich);
        }

        // POST: Baivietdulich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var baivietdulich = await _context.Baivietdulich.FindAsync(id);
            _context.Baivietdulich.Remove(baivietdulich);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaivietdulichExists(string id)
        {
            return _context.Baivietdulich.Any(e => e.BvdlMa == id);
        }
    }
}
