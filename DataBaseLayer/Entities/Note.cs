using System.Collections.Generic;

namespace DataBaseLayer.Entities
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Color { get; set; } = "#FFFFFF";

        public bool IsPinned { get; set; }
        public bool IsArchived { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<Label> Labels { get; set; } = new HashSet<Label>();
        public ICollection<Collaborator> Collaborators { get; set; } = new HashSet<Collaborator>();
    }
}
