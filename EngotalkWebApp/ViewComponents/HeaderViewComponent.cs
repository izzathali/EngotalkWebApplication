using Engotalk.IBL;
using Microsoft.AspNetCore.Mvc;

namespace Engotalk.WebApp.ViewComponents
{
    [ViewComponent(Name ="Header")]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICountryRepository iCountryRepository;
        public HeaderViewComponent(ICountryRepository countryRepository)
        {
            this.iCountryRepository = countryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var country = iCountryRepository.GetCountries();
            return View(country);
        }
    }
}
