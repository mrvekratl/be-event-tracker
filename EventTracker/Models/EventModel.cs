using System.ComponentModel.DataAnnotations;

namespace EventTracker.Models
{
    public class EventModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(2)]
        public string Title { get; set; } = null!;  
        public string Description { get; set; } = null!;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Image { get; set; } = null!;

    }
}
