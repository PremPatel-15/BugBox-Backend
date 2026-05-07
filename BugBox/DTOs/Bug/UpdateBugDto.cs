using System.ComponentModel.DataAnnotations;

namespace BugBox.DTOs.Bug
{
    public class UpdateBugDto
    {
        [Required]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public string Priority { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;

        [Required]
        public string Rootcause { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        public string? AssignedTo { get; set; }
    }
}
