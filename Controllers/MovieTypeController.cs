using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using NuGet.Protocol;

namespace Movie.Controllers
{
    public class MovieTypeController : Controller
    {
        private readonly appDbContext _context;
        public MovieTypeController(appDbContext context)
        {
            _context = context;
        }

        // GET: MovieTypeController
        public async Task<IActionResult> Index()
        {
            var db = _context.MovieTypes;
            return View(await db.ToListAsync());
        }
        // GET: MovieTypeController/Details/5
        public IActionResult Details(int id)
        {
            if(id == null || _context.MovieTypes == null)
            {
                return NotFound();
            }
            var mtype = _context.MovieTypes.Find(id);
            if(mtype == null)
            {
                return NotFound();
            }
            return View(mtype);
        }

        // GET: MovieTypeController/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieType mtype)
        {
            if (ModelState.IsValid)
            {
                _context.MovieTypes.Add(mtype);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mtype);
        }

        // GET: MovieTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if(id == null || _context.MovieTypes == null)
            {
                return NotFound();
            }
            var mtype = _context.MovieTypes.Find(id);
            if(mtype == null)
            {
                return NotFound();
            }
            return View(mtype);
        }

        // POST: MovieTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MovieType mtype)
        {
            if(id != mtype.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                    _context.Attach(mtype);
                    _context.Entry(mtype).State = EntityState.Added;
                    _context.Update(mtype);
                    _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MovieTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || _context.MovieTypes == null)
            {
                return NotFound();
            }
            var mtype = _context.MovieTypes.Find(id);
            if(mtype == null)
            {
                return NotFound();
            }
            return View(mtype);
        }

        // POST: MovieTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, MovieType mtype)
        {
            if (_context.MovieTypes == null) {
                return Problem("Enity set 'appDbContext.MovieType' is null.");
            }
            var mType = _context.MovieTypes.Find(id);
            if(mType != null)
            {
                _context.MovieTypes.Remove(mType);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
