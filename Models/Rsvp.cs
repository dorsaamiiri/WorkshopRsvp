using System.ComponentModel.DataAnnotations;

namespace WorkshopRsvp.Models
{
    public class Rsvp
    {
        [Required(ErrorMessage = "Please enter your full name.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = "";

        [Display(Name = "I need an accommodation")]
        public bool NeedsAccommodation { get; set; }

        [Required(ErrorMessage = "Please choose a workshop.")]
        [Display(Name = "Workshop")]
        public string WorkshopTitle { get; set; } = "";
    }
}