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

            return View(await iUniversityRepository.GetUniversitiesOrderByLastAdded());
        }

        // GET: UniversityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");

            return View();
        }

        // POST: UniversityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("UniversityId,UniversityType,University,CountryId,Rank")] UniversityM universityM)
        {
            try
            {
                if (universityM.UniversityType != "--SELECT--" && !String.IsNullOrEmpty(universityM.University) && universityM.CountryId > 0)
                {
                    await iUniversityRepository.AddUniversity(universityM);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
            }
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");

            return View();
        }

        // GET: UniversityController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");

            var university = await iUniversityRepository.GetUniversitiesByUniversityId(id);

            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        // POST: UniversityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("UniversityId,UniversityType,University,CountryId,Rank")] UniversityM universityM)
        {
            try
            {
                if (universityM.UniversityType != "--SELECT--" && !String.IsNullOrEmpty(universityM.University) && universityM.CountryId > 0)
                {
                    await iUniversityRepository.UpdateUniversity(universityM);
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
            }

            ViewData["CountryId"] = new SelectList(await iCountryRepository.GetCountriesAsync(), "CountryId", "CountryName");
            return View(universityM);
        }

        // GET: UniversityController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await iUniversityRepository.DeleteUniversity(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
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
