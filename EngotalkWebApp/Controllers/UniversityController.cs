using Engotalk.IBL;
using Engotalk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Engotalk.WebApp.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository iUniversityRepository;
        private readonly ICountryRepository iCountryRepository;
        public UniversityController(IUniversityRepository iUniversityRepository, ICountryRepository iCountryRepository)
        {
            this.iUniversityRepository = iUniversityRepository;
            this.iCountryRepository = iCountryRepository;
        }

        // GET: UniversityController
        public async Task<ActionResult> Index()
        {
            
            return View(await iUniversityRepository.GetUniversities());
        }

        // GET: UniversityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountries(), "CountryId", "CountryName");

            return View();
        }

        // POST: UniversityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("UniversityId,University,CountryId,Rank")] UniversityM universityM)
        {
            try
            {
                if (!String.IsNullOrEmpty(universityM.University) && universityM.CountryId > 0)
                {
                    await iUniversityRepository.AddUniversity(universityM);
                    return RedirectToAction(nameof(Index));
                }

                ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountries(), "CountryId", "CountryName");
                return View();
            }
            catch
            {
                ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountries(), "CountryId", "CountryName");
                return View();
            }
        }

        // GET: UniversityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityController/Edit/5
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

        // GET: UniversityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityController/Delete/5
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
