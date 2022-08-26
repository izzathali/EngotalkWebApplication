using Engotalk.IBL;
using Engotalk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Engotalk.WebApp.Controllers
{
    public class CourseTitleController : Controller
    {
        private readonly ICourseRepository iCourseRepository;
        public CourseTitleController(ICourseRepository iCourseRepository)
        {
            this.iCourseRepository = iCourseRepository;
        }
        // GET: CourseTitleController
        public async Task<ActionResult> Index()
        {
            return View(await iCourseRepository.GetCourseTitles());
        }

        // GET: CourseTitleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseTitleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseTitleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("CourseTitleId,CourseTitle")] CourseTitleM courseTitleM)
        {
            try
            {
                if (!string.IsNullOrEmpty(courseTitleM.CourseTitle))
                {
                    await iCourseRepository.AddCourseTitle(courseTitleM);
                    return RedirectToAction(nameof(Index));

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseTitleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseTitleController/Edit/5
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

        // GET: CourseTitleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseTitleController/Delete/5
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
