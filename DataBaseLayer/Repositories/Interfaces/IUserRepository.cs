using DataBaseLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //Read
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);

        //Write
        Task AddAsync(User user);
        Task UpdateAsync(User user);

        //Validation helper 
        Task<bool> EmailExistsAsync(string email);

    }
}
