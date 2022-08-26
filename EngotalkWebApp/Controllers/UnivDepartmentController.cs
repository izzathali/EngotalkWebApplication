using Engotalk.IBL;
using Engotalk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Engotalk.WebApp.Controllers
{
    public class UnivDepartmentController : Controller
    {
        private readonly IUniversityRepository iUniversityRepository;
        private readonly IDepartmentRepository iDepartmentRepository;
        public UnivDepartmentController(IUniversityRepository iUniversityRepository, IDepartmentRepository iDepartmentRepository)
        {
            this.iUniversityRepository = iUniversityRepository;
            this.iDepartmentRepository = iDepartmentRepository;
        }

        // GET: UnivDepartmentController
        public async Task<ActionResult> Index()
        {
            return View(await iUniversityRepository.GetUniversityDepartmentsAsync());
        }

        // GET: UnivDepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnivDepartmentController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["UniversityId"] = new SelectList(await iUniversityRepository.GetUniversities(), "UniversityId", "UnivWithCountry");
            ViewData["DepartmentId"] = new SelectList(await iDepartmentRepository.GetDepartments(), "DepartmentId", "Department");

            return View();
        }

        // POST: UnivDepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("UniversityDepartmentId,UniversityId,DepartmentId")] UniversityDepartmentsM universityDepartmentsM)
        {
            if (universityDepartmentsM.UniversityId > 0 && universityDepartmentsM.DepartmentId > 0)
            {
                try
                {
                    await iUniversityRepository.AddUniversityDepartments(universityDepartmentsM);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                   
                }
            }
            ViewData["UniversityId"] = new SelectList(await iUniversityRepository.GetUniversities(), "UniversityId", "UnivWithCountry");
            ViewData["DepartmentId"] = new SelectList(await iDepartmentRepository.GetDepartments(), "DepartmentId", "Department");

            return View();
        }

        // GET: UnivDepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnivDepartmentController/Edit/5
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

        // GET: UnivDepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnivDepartmentController/Delete/5
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
