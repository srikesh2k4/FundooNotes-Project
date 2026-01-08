using DataBaseLayer.Context;
using DataBaseLayer.Entities;
using DataBaseLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLayer.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly FundooAppDbContext _context;

        public CollaboratorRepository(FundooAppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Collaborator collaborator)
        {
            await _context.Collaborators.AddAsync(collaborator);
        }

        public async Task<Collaborator?> GetByIdAsync(int id)
        {
            return await _context.Collaborators
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsAsync(int noteId, int collaboratorUserId)
        {
            return await _context.Collaborators
                .AnyAsync(c =>
                    c.NoteId == noteId &&
                    c.CollaboratorId == collaboratorUserId);
        }

        public async Task DeleteAsync(Collaborator collaborator)
        {
            _context.Collaborators.Remove(collaborator);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
