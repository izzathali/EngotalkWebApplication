using Engotalk.IBL;
using Engotalk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Engotalk.WebApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository iCourseRepository;
        private readonly IUniversityRepository iUniversityRepository;
        public CourseController(ICourseRepository iCourseRepository, IUniversityRepository iUniversityRepository)
        {
            this.iCourseRepository = iCourseRepository;
            this.iUniversityRepository = iUniversityRepository;
        }

        // GET: CourseController
        public async Task<ActionResult> Index()
        {


            return View(await iCourseRepository.GetCourses());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["CourseTitleId"] = new SelectList(await iCourseRepository.GetCourseTitles(), "CourseTitleId", "CourseTitle");
            ViewData["UniversityDepartmentId"] = new SelectList(await iUniversityRepository.GetUniversityDepartmentsAsync(), "UniversityDepartmentId", "UnivDept");

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("CourseId,CourseTitleId,UniversityDepartmentId,Band,Cost,CourseDuration")] CourseM courseM)
        {
            if (courseM.CourseTitleId > 0 && courseM.UniversityDepartmentId > 0 && !String.IsNullOrEmpty(courseM.Band.ToString()) && !String.IsNullOrEmpty(courseM.Cost.ToString()) && !String.IsNullOrEmpty(courseM.CourseDuration))
            {
                try
                {
                    await iCourseRepository.AddCourse(courseM);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                }


            }

            ViewData["CourseTitleId"] = new SelectList(await iCourseRepository.GetCourseTitles(), "CourseTitleId", "CourseTitle");
            ViewData["UniversityDepartmentId"] = new SelectList(await iUniversityRepository.GetUniversityDepartmentsAsync(), "UniversityDepartmentId", "UnivDept");
            
            return View();
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
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

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
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
