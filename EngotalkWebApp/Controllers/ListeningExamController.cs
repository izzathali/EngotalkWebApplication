using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Engotalk.WebApp.Controllers
{
    public class ListeningExamController : Controller
    {
        // GET: ListeningExamController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ListeningExamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListeningExamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListeningExamController/Create
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

        // GET: ListeningExamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListeningExamController/Edit/5
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

        // GET: ListeningExamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListeningExamController/Delete/5
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
