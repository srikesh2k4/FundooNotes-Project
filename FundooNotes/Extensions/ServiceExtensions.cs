using BusinessLayer.Interfaces.Services;
using BusinessLayer.Services;
using DataBaseLayer.Context;
using DataBaseLayer.Repositories;
using FundooNotes.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FundooNotes.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            // DbContext
            services.AddDbContext<FundooAppDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection")));

            // Helpers
            services.AddScoped<JwtTokenGenerator>();
            services.AddScoped<OtpEmailSender>();

            // Repositories (Data Access Layer)
            services.AddScoped<DataBaseLayer.Interfaces.IUserRepository, UserRepository>();
            services.AddScoped<DataBaseLayer.Interfaces.INoteRepository, NoteRepository>();
            services.AddScoped<DataBaseLayer.Interfaces.ILabelRepository, LabelRepository>();

            // ✅ FIXED: Fully qualified interface + implementation
            services.AddScoped<
                DataBaseLayer.Interfaces.ICollaboratorRepository,
                DataBaseLayer.Repositories.CollaboratorRepository>();

            // Services (Business Layer)
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<ILabelService, LabelService>();
            services.AddScoped<ICollaboratorService, CollaboratorService>();
        }
    }
}
