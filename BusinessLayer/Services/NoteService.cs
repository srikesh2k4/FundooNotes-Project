using BusinessLayer.Interfaces.Services;
using BusinessLayer.Rules;
using DataBaseLayer.Entities;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs.Notes;

namespace BusinessLayer.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<NoteResponseDto> CreateAsync(CreateNoteDto dto, int userId)
        {
            NoteRules.ValidateCreate(dto);

            var note = new Note
            {
                Title = dto.Title,
                Content = dto.Content,
                Color = dto.Color,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };

            await _noteRepository.AddAsync(note);
            await _noteRepository.SaveAsync();

            return new NoteResponseDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                Color = note.Color,
                CreatedAt = note.CreatedAt
            };
        }
    }
}
