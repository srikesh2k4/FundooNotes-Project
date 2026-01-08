using DataBaseLayer.Entities;

namespace DataBaseLayer.Interfaces
{
    public interface INoteRepository
    {
        Task AddAsync(Note note);
        Task<Note?> GetByIdAsync(int id);
        Task<IEnumerable<Note>> GetByUserAsync(int userId);
        Task DeleteAsync(Note note);
        Task SaveAsync();
    }
}
