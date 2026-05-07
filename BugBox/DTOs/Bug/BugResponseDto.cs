namespace BugBox.DTOs.Bug
{
    public class BugResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Priority { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Rootcause { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? AssignedTo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}