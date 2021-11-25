using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiGestores.Controllers
{
    public class ProvinciasController : Controller
    {
        // GET: ProvinciasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProvinciasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProvinciasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvinciasController/Create
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

        // GET: ProvinciasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProvinciasController/Edit/5
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

        // GET: ProvinciasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProvinciasController/Delete/5
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
