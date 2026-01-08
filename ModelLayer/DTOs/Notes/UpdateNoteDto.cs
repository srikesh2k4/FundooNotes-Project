namespace ModelLayer.DTOs.Notes
{
    public class UpdateNoteDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Color { get; set; } = "#FFFFFF";
        public bool IsPinned { get; set; }
        public bool IsArchived { get; set; }
    }
}
