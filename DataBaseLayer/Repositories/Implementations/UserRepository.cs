using DataBaseLayer.Context;
using DataBaseLayer.Entities;
using DataBaseLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly FundooNotesDbContext _dbContext;
        public UserRepository(FundooNotesDbContext fundooNotesDbContext)
        {
            _dbContext = fundooNotesDbContext;
        }
        public async Task IUserRepository.AddAsync(User user)
        {
            if (user is not null)
            {
                await _dbContext.users.AddAsync(user);
            }
            await _dbContext.SaveChangesAsync();


        }

        Task<bool> IUserRepository.EmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
