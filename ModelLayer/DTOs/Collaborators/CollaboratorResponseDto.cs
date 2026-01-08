using ModelLayer.Enums;

namespace ModelLayer.DTOs.Collaborators
{
    public class CollaboratorResponseDto
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public PermissionLevel Permission { get; set; }
    }
}
