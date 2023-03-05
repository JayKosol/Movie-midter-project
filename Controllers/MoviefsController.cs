using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;

namespace Movie.Controllers
{
    public class MoviefsController : Controller
    {
        private readonly appDbContext _context;

        public MoviefsController(appDbContext context)
        {
            _context = context;
        }

        // GET: Moviefs
        public async Task<IActionResult> Index()
        {
            ViewBag.Genre_RefID = new SelectList(_context.MovieTypes, "Id", "GenreName");
            var appDbContext = _context.Movies.Include(m => m.MovieType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Moviefs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movief = await _context.Movies
                .Include(m => m.MovieType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movief == null)
            {
                return NotFound();
            }

            return View(movief);
        }

        // GET: Moviefs/Create
        public IActionResult Create()
        {
            ViewBag.Genre_RefID = new SelectList(_context.MovieTypes, "Id", "GenreName");
            return View();
        }

        // POST: Moviefs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movief movief)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movief);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Genre_RefID"] = new SelectList(_context.MovieTypes, "Id", "GenreName", movief.Genre_RefID);
            return View(movief);
        }

        // GET: Moviefs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movief = await _context.Movies.FindAsync(id);
            if (movief == null)
            {
                return NotFound();
            }
            ViewData["Genre_RefID"] = new SelectList(_context.MovieTypes, "Id", "GenreName", movief.Genre_RefID);
            return View(movief);
        }

        // POST: Moviefs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Duration,SubTitle,ReleseDate,Language,Genre_RefID")] Movief movief)
        {
            if (id != movief.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movief);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviefExists(movief.Id))
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
            ViewData["Genre_RefID"] = new SelectList(_context.MovieTypes, "Id", "GenreName", movief.Genre_RefID);
            return View(movief);
        }

        // GET: Moviefs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movief = await _context.Movies
                .Include(m => m.MovieType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movief == null)
            {
                return NotFound();
            }

            return View(movief);
        }

        // POST: Moviefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'appDbContext.Movies'  is null.");
            }
            var movief = await _context.Movies.FindAsync(id);
            if (movief != null)
            {
                _context.Movies.Remove(movief);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviefExists(int id)
        {
          return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
