using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notyf;
        public CourseController(ICourseRepository iCourseRepository, IUniversityRepository iUniversityRepository, ICountryRepository iCountryRepository, IDepartmentRepository iDepartmentRepository, INotyfService notyf)
        {
            this.iCourseRepository = iCourseRepository;
            this.iUniversityRepository = iUniversityRepository;
            this.iCountryRepository = iCountryRepository;
            this.iDepartmentRepository = iDepartmentRepository;
            _notyf = notyf;
        }

        // GET: CourseController
        public async Task<ActionResult> Index()
        {
            ViewBag.Current = "CourseReport";
            //ViewBag.Colleges = await iCourseRepository.GetCoursesByInstituteType("College");

            ViewBag.Country = await iCourseRepository.GetCoursesGroupByCountryAndUniversityAndDepartment();

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
            ViewBag.Current = "CourseCreate";
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");

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
        public async Task<JsonResult> GetUniversityType(int id)
        {
            var type = await iUniversityRepository.GetUniversityTypeByUniversityId(id);

            return Json(type);
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Course,DepartmentId,IELTSBand,Cost,CourseDuration,GREScore,TOEFLScore,SATScore")] CourseM courseM)
        {

            try
            {
                if (courseM.DepartmentId > 0 && !String.IsNullOrEmpty(courseM.Course))
                {
                    await iCourseRepository.AddCourse(courseM);
                    _notyf.Success("Course Saved Successfully!!", 3);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                _notyf.Error("Somthing went wrong!!", 3);
            }
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");

            return View();
        }

        // GET: CourseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                ViewBag.Current = "CourseReport";

                var course = await iCourseRepository.GetCoursByCourseId(id);

                if (course == null)
                {
                    return NotFound();
                }

                int CountryId = course.department.university.CountryId;
                int UnivId = course.department.UniversityId;
                int DeptId = course.DepartmentId;

                ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName", CountryId);
                ViewData["UniversityId"] = new SelectList(await iUniversityRepository.GetUniversitiesByCountryId(CountryId), "UniversityId", "University", UnivId);
                ViewData["DepartmentId"] = new SelectList(await iDepartmentRepository.GetDepartmentsByUnivId(UnivId), "DepartmentId", "Department", DeptId);

                return View(course);

            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("CourseId,Course,DepartmentId,IELTSBand,Cost,CourseDuration,GREScore,TOEFLScore,SATScore")] CourseM courseM)
        {
            try
            {
                if (courseM.DepartmentId > 0 && !String.IsNullOrEmpty(courseM.Course))
                {
                    await iCourseRepository.UpdateCourse(courseM);
                    _notyf.Success("Course Updated Successfully!!", 5);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                _notyf.Error("Somthing went wrong!!", 3);
            }
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");
            return View(courseM);
        }

        // GET: CourseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await iCourseRepository.DeleteCourse(id);
                _notyf.Success("Course Deleted Successfully!!", 5);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
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
