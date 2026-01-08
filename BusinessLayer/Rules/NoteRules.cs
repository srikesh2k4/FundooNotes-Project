using BusinessLayer.Exceptions;
using ModelLayer.DTOs.Notes;

namespace BusinessLayer.Rules
{
    public static class NoteRules
    {
        public static void ValidateCreate(CreateNoteDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ValidationException("Title is required");
        }
    }
}
