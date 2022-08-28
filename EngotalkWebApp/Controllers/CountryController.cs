using AspNetCoreHero.ToastNotification.Abstractions;
using Engotalk.IBL;
using Engotalk.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Engotalk.WebApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryRepository iCountryRepository;
        private readonly INotyfService _notyf;
        public CountryController(ICountryRepository _iCountryRepository,INotyfService notyf)
        {
            iCountryRepository = _iCountryRepository;
            _notyf = notyf;
        }
        // GET: CountryController
        public async Task<ActionResult> Index()
        {
            ViewBag.Current = "CountryReport";
            return View(await iCountryRepository.GetCountriesAsync());
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            ViewBag.Current = "CountryCreate";
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("CountryId,CountryName")] CountryM country)
        {

            try
            {
                if (!String.IsNullOrEmpty(country.CountryName))
                {
                    await iCountryRepository.AddCountry(country);

                    _notyf.Success("Country Saved Successfully !!", 5);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
            }

            return View();
        }

        // GET: CountryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Current = "CountryReport";

            var category = await iCountryRepository.GetCountryByCountryId(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("CountryId,CountryName")] CountryM country)
        {
            try
            {
                if (!String.IsNullOrEmpty(country.CountryName))
                {
                    await iCountryRepository.UpdateCountry(country);

                    _notyf.Success("Country Updated Successfully", 5);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
            }
            return View(country);
        }

        // GET: CountryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                ViewBag.Current = "CountryReport";

                await iCountryRepository.DeleteCountry(id);
                _notyf.Success("Country Deleted Successfully", 5);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            return View();
        }
    }
}
