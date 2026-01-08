using DataBaseLayer.Enums;

namespace DataBaseLayer.Entities
{
    public class Collaborator
    {
        public int Id { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; } = null!;

        public int CollaboratorId { get; set; }
        public User CollaboratorUser { get; set; } = null!;

        public PermissionLevel Permission { get; set; }
    }
}
