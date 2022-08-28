using AspNetCoreHero.ToastNotification.Abstractions;
using Engotalk.IBL;
using Engotalk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Engotalk.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository iDepartmentRepository;
        private readonly IUniversityRepository iUniversityRepository;
        private readonly INotyfService _notyf;
        public DepartmentController(IDepartmentRepository iDepartmentRepository, IUniversityRepository iUniversityRepository,INotyfService notyf)
        {
            this.iDepartmentRepository = iDepartmentRepository;
            this.iUniversityRepository = iUniversityRepository;
            _notyf = notyf;
        }

        // GET: DepartmentController
        public async Task<ActionResult> Index()
        {

            return View(await iDepartmentRepository.GetDepartments());
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["UniversityId"] = new SelectList(await iUniversityRepository.GetUniversities(), "UniversityId", "University");

            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("DepartmentId,Department,UniversityId")] DepartmentM departmentM)
        {
            try
            {
                if (!string.IsNullOrEmpty(departmentM.Department) && departmentM.UniversityId > 0)
                {
                    await iDepartmentRepository.AddDepartment(departmentM);
                    _notyf.Success("Department Saved Successfully !!", 5);

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["UniversityId"] = new SelectList(await iUniversityRepository.GetUniversities(), "UniversityId", "University");

            var department = await iDepartmentRepository.GetDepartmentByDepartmentId(id);

            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("DepartmentId,Department,UniversityId")] DepartmentM departmentM)
        {
            try
            {
                if (!string.IsNullOrEmpty(departmentM.Department) && departmentM.UniversityId > 0)
                {
                    await iDepartmentRepository.UpdateDepartment(departmentM);
                    _notyf.Success("Department Updated Successfully!!", 5);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
            }

            ViewData["UniversityId"] = new SelectList(await iUniversityRepository.GetUniversities(), "UniversityId", "University");
            return View(departmentM);
        }

        // GET: DepartmentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await iDepartmentRepository.DeleteDepartment(id);
                _notyf.Success("Department Deleted Successfully!!", 5);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: DepartmentController/Delete/5
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
