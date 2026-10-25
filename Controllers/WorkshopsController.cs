using Microsoft.AspNetCore.Mvc;
using WorkshopRsvp.Models;

namespace WorkshopRsvp.Controllers
{
    public class WorkshopsController : Controller
    {
        // In-memory list of registrations, shared by all requests (static).
        // It resets whenever the app restarts, which is fine for this lab.
        private static readonly List<Rsvp> _registrations = new List<Rsvp>
        {
            new Rsvp { FullName = "Alex Martin", NeedsAccommodation = false, WorkshopTitle = "Routing Basics" },
            new Rsvp { FullName = "Priya Singh", NeedsAccommodation = true,  WorkshopTitle = "Razor Essentials" }
        };

        // The workshops people can choose from
        private static readonly string[] _workshops =
        {
            "Routing Basics",
            "EF Core Intro",
            "Razor Essentials"
        };

        // GET: /Workshops
        // Landing page describing the RSVP feature
        public IActionResult Index()
        {
            ViewData["Title"] = "Workshops";
            ViewData["Workshops"] = _workshops;
            return View();
        }

        // GET: /Workshops/RsvpForm
        // Shows the empty RSVP form
        [HttpGet]
        public IActionResult RsvpForm()
        {
            ViewData["Workshops"] = _workshops;
            return View();
        }

        // POST: /Workshops/Confirm
        // Receives the submitted form as an Rsvp model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(Rsvp model)
        {
            // If required fields are missing, show the form again with error messages
            if (!ModelState.IsValid)
            {
                ViewData["Workshops"] = _workshops;
                return View("RsvpForm", model);
            }

            _registrations.Add(model);

            ViewData["Message"] = $"Thanks for registering, {model.FullName}!";
            return View(model); // strongly typed view: Confirm.cshtml
        }

        // GET: /Workshops/Registrations
        // Shows all RSVPs in a table
        public IActionResult Registrations()
        {
            return View(_registrations);
        }
    }
}