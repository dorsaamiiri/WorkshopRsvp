using Microsoft.AspNetCore.Mvc;
using WorkshopRsvp.Data;
using WorkshopRsvp.Models;

namespace WorkshopRsvp.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        // The DbContext is given to us by dependency injection (registered in Program.cs)
        public WorkshopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // The workshops people can choose from
        private static readonly string[] _workshops =
        {
            "Routing Basics",
            "EF Core Intro",
            "Razor Essentials"
        };

        // GET: /Workshops
        public IActionResult Index()
        {
            ViewData["Title"] = "Workshops";
            ViewData["Workshops"] = _workshops;
            return View();
        }

        // GET: /Workshops/RsvpForm
        [HttpGet]
        public IActionResult RsvpForm()
        {
            ViewData["Workshops"] = _workshops;
            return View();
        }

        // POST: /Workshops/Confirm
        // Shows the confirmation (saving to the database is not required in Lab 4)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(Rsvp model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Workshops"] = _workshops;
                return View("RsvpForm", model);
            }

            ViewData["Message"] = $"Thanks for registering, {model.FullName}!";
            return View(model);
        }

        // GET: /Workshops/Registrations
        // Reads all RSVPs from the database
        public IActionResult Registrations()
        {
            List<Rsvp> registrations = _context.Rsvps
                .OrderBy(r => r.Id)
                .ToList();

            return View(registrations);
        }
    }
}