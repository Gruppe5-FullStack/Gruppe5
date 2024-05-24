using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gruppe5.Data;
using Gruppe5.Services;

namespace Gruppe5.Controllers
{
    public class ObservasjonController : Controller
    {
        private readonly Gruppe5Context _context; // Database kontekst
        private readonly WeatherService _weatherService; // Tjeneste for å hente data

        public ObservasjonController(Gruppe5Context context, WeatherService weatherService)
        {
            _context = context;
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            // Hent data.
            // Dette gjør at data hentes fra yr sitt api hver gang applikasjonen kjøres, derfor kan det noen ganger
            // ta lengre tid når man trykker på knappen "Observasjoner" i venstre-meny.
            await _weatherService.FetchAndStoreWeatherDataAsync();

            // Vise kun de 7 siste dagene ved å sortere og vise første 7
            var observasjoner = await _context.Observation
                .OrderByDescending(o => o.Date)
                .Take(7)
                .ToListAsync();

            return View("~/Views/Observation/Index.cshtml", observasjoner);
        }
    }
}
