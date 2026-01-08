using ModelLayer.DTOs.Notes;

namespace BusinessLayer.Interfaces.Services
{
    public interface INoteService
    {
        Task<NoteResponseDto> CreateAsync(CreateNoteDto dto, int userId);
    }
}
