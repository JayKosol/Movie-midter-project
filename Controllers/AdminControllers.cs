using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers
{
    public class AdminControllers : Controller
    {
        // GET: AdminControllers
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminControllers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminControllers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
