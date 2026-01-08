using DataBaseLayer.Context;
using DataBaseLayer.Entities;
using DataBaseLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayer.Repositories
{
    public class LabelRepository : ILabelRepository
    {
        private readonly FundooAppDbContext _context;

        public LabelRepository(FundooAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Label label)
        {
            await _context.Labels.AddAsync(label);
        }

        public async Task<IEnumerable<Label>> GetByUserAsync(int userId)
        {
            return await _context.Labels
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<Label?> GetByIdAsync(int id)
        {
            return await _context.Labels.FindAsync(id);
        }

        public Task DeleteAsync(Label label)
        {
            _context.Labels.Remove(label);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
