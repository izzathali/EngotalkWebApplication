using Engotalk.IBL;
using Engotalk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Engotalk.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository iDepartmentRepository;
        public DepartmentController(IDepartmentRepository iDepartmentRepository)
        {
            this.iDepartmentRepository = iDepartmentRepository;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("DepartmentId,Department")] DepartmentM departmentM)
        {
            try
            {
                if (!string.IsNullOrEmpty(departmentM.Department))
                {
                    await iDepartmentRepository.AddDepartment(departmentM);
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
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

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
