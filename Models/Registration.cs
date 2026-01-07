using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public DateTime RegisteredOn { get; set; } = DateTime.UtcNow;

        public Event? Event { get; set; }
    }
}
