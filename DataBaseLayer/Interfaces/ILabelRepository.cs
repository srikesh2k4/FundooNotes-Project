using DataBaseLayer.Entities;

namespace DataBaseLayer.Interfaces
{
    public interface ILabelRepository
    {
        Task AddAsync(Label label);
        Task<IEnumerable<Label>> GetByUserAsync(int userId);
        Task<Label?> GetByIdAsync(int id);
        Task DeleteAsync(Label label);
        Task SaveAsync();
    }
}
