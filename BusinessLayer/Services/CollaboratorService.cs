using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces.Services;
using DataBaseLayer.Entities;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs.Collaborators;

namespace BusinessLayer.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        private readonly INoteRepository _noteRepository;

        public CollaboratorService(
            ICollaboratorRepository collaboratorRepository,
            INoteRepository noteRepository)
        {
            _collaboratorRepository = collaboratorRepository;
            _noteRepository = noteRepository;
        }

        public async Task AddAsync(AddCollaboratorDto dto, int ownerUserId)
        {
            var note = await _noteRepository.GetByIdAsync(dto.NoteId)
                ?? throw new NotFoundException("Note not found");

            if (note.UserId != ownerUserId)
                throw new UnauthorizedException("Only owner can add collaborators");

            if (await _collaboratorRepository.ExistsAsync(dto.NoteId, dto.UserId))
                throw new ValidationException("Collaborator already exists");

            var collaborator = new Collaborator
            {
                NoteId = dto.NoteId,
                CollaboratorId = dto.UserId,
                Permission = (DataBaseLayer.Enums.PermissionLevel)dto.Permission
            };

            await _collaboratorRepository.AddAsync(collaborator);
            await _collaboratorRepository.SaveAsync();
        }

        public async Task RemoveAsync(int collaboratorId, int ownerUserId)
        {
            var collaborator = await _collaboratorRepository.GetByIdAsync(collaboratorId)
                ?? throw new NotFoundException("Collaborator not found");

            var note = await _noteRepository.GetByIdAsync(collaborator.NoteId)
                ?? throw new NotFoundException("Note not found");

            if (note.UserId != ownerUserId)
                throw new UnauthorizedException("Only owner can remove collaborators");

            await _collaboratorRepository.DeleteAsync(collaborator);
            await _collaboratorRepository.SaveAsync();
        }
    }
}
