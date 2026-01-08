using System.Collections.Generic;

namespace DataBaseLayer.Entities
{
    public class Label
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();
    }
}
