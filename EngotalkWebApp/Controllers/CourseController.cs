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
        private readonly ICountryRepository iCountryRepository;
        private readonly IUniversityRepository iUniversityRepository;
        private readonly IDepartmentRepository iDepartmentRepository;
        public CourseController(ICourseRepository iCourseRepository, IUniversityRepository iUniversityRepository, ICountryRepository iCountryRepository, IDepartmentRepository iDepartmentRepository)
        {
            this.iCourseRepository = iCourseRepository;
            this.iUniversityRepository = iUniversityRepository;
            this.iCountryRepository = iCountryRepository;
            this.iDepartmentRepository = iDepartmentRepository;
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
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");
            //ViewData["UniversityId"] = new SelectList(await iUniversityRepository.GetUniversities(), "UniversityId", "University");
            //ViewData["DepartmentId"] = new SelectList(await iDepartmentRepository.GetDepartments(), "DepartmentId", "Department");

            return View();
        }
        public async Task<JsonResult> LoadUniversities(int id)
        {
            var universities = await iUniversityRepository.GetUniversitiesByCountryId(id);

            return Json(new SelectList(universities, "UniversityId", "University"));
        }
        public async Task<JsonResult> LoadDepartments(int id)
        {
            var departments = await iDepartmentRepository.GetDepartmentsByUnivId(id);

            return Json(new SelectList(departments, "DepartmentId", "Department"));
        }
    

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Course,DepartmentId,Band,Cost,CourseDuration,IELTSRequirment,ListeningBand,ReadingBand,WritingBand,SpeakingBand")] CourseM courseM)
        {
            if (courseM.DepartmentId > 0 && !String.IsNullOrEmpty(courseM.Band.ToString()) && !String.IsNullOrEmpty(courseM.Cost.ToString()) && !String.IsNullOrEmpty(courseM.CourseDuration))
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
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");
            //ViewData["UniversityId"] = new SelectList(await iUniversityRepository.GetUniversities(), "UniversityId", "University");
            //ViewData["DepartmentId"] = new SelectList(await iDepartmentRepository.GetDepartments(), "DepartmentId", "Department");

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
