using Engotalk.IBL;
using EngotalkWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EngotalkWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseRepository iCourseRepository;
        private readonly IUniversityRepository iUniversityRepository;
        public HomeController(ILogger<HomeController> logger,ICourseRepository courseRepository, IUniversityRepository iUniversityRepository)
        {
            _logger = logger;
            iCourseRepository = courseRepository;
            this.iUniversityRepository = iUniversityRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        // GET: HomeController/Departments/5
        public async Task<IActionResult> Departments(int cid)
        {
            var model = await iCourseRepository.GetDepartmentWithCourse(cid);
            ViewBag.Departments = model;
            ViewBag.CountryId = cid;

            return View();
        }
        // GET: HomeController/Universities/Engineering
        public async Task<IActionResult> Universities(int cid,string course)
        {
            ViewBag.Course = course;
            var model = await iUniversityRepository.GetInstituteByCountryIdAndCourse(cid,course);
            ViewBag.Institutes = model;

            //var colleges = await iUniversityRepository.GetCollegesByCountryIdAndCourse(cid, course);
            //ViewBag.Colleges = colleges;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}