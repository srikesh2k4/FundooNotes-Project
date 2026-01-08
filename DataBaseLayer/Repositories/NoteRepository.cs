using DataBaseLayer.Context;
using DataBaseLayer.Entities;
using DataBaseLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayer.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly FundooAppDbContext _context;

        public NoteRepository(FundooAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
        }

        public async Task<Note?> GetByIdAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task<IEnumerable<Note>> GetByUserAsync(int userId)
        {
            return await _context.Notes
                .Where(n => n.UserId == userId)
                .ToListAsync();
        }

        public Task DeleteAsync(Note note)
        {
            _context.Notes.Remove(note);
            return Task.CompletedTask;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
