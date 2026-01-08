using ModelLayer.DTOs.Collaborators;

namespace BusinessLayer.Interfaces.Services
{
    public interface ICollaboratorService
    {
        Task AddAsync(AddCollaboratorDto dto, int ownerUserId);
        Task RemoveAsync(int collaboratorId, int ownerUserId);
    }
}
