using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gruppe5.Data;

namespace Gruppe5.Controllers
{
    public class ObservasjonController : Controller
    {
        private readonly Gruppe5Context _context;

        public ObservasjonController(Gruppe5Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Vis data fra 7 siste dager
            var observasjoner = await _context.Observation
                .OrderByDescending(o => o.Date)
                .Take(7)
                .ToListAsync();

            return View("~/Views/Observation/Index.cshtml", observasjoner); // localhost:7054/Observasjon
        }

    }
}
