using DataBaseLayer.Entities;

namespace DataBaseLayer.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task AddAsync(Collaborator collaborator);
        Task<Collaborator?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int noteId, int collaboratorUserId);
        Task DeleteAsync(Collaborator collaborator);
        Task SaveAsync();
    }
}
