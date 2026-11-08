using Microsoft.EntityFrameworkCore;
using WorkshopRsvp.Models;

namespace WorkshopRsvp.Data
{
    public static class DbInitializer
    {
        // Creates/updates the database and adds starting data if the table is empty
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate(); // applies migrations (creates DB + Rsvps table)

            if (context.Rsvps.Any())
            {
                return; // already seeded
            }

            context.Rsvps.AddRange(
                new Rsvp { FullName = "Dorsa Amiri", NeedsAccommodation = false, WorkshopTitle = "Routing Basics" },
                new Rsvp { FullName = "Parsa Amiri", NeedsAccommodation = true, WorkshopTitle = "Razor Essentials" },
                new Rsvp { FullName = "Sani pati", NeedsAccommodation = false, WorkshopTitle = "EF Core Intro" },
                new Rsvp { FullName = "luna graham", NeedsAccommodation = true, WorkshopTitle = "EF Core Intro" }
            );

            context.SaveChanges();
        }
    }
}