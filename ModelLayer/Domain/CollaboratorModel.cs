using ModelLayer.Enums;

namespace ModelLayer.Domain
{
    public class CollaboratorModel
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public PermissionLevel Permission { get; set; }
    }
}
