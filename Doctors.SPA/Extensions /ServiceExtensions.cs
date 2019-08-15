using System;
using Doctors.Business;
using Doctors.Data.Context;
using Doctors.Data.Infrastruture;
using Doctors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Doctors.SPA.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlite(this IServiceCollection services, IConfiguration config)
        {
            // var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<RepositoryContext>(x => x.UseSqlite(config.GetConnectionString("DefaultConnection"),
                s => s.MigrationsAssembly("Doctors.SPA")));
        }

        public static void ConfigureBusiness(this IServiceCollection services)
        {
            services.AddScoped<IDoctorBus, DoctorBus>();
            services.AddScoped<ILanguageBus, LanguageBus>();
            services.AddScoped<IMedicalSchoolBus, MedicalSchoolBus>();
            services.AddScoped<IPatientRatingBus, PatientRatingBus>();
            services.AddScoped<ISpecialtyBus, SpecialtyBus>();
            services.AddScoped<IUserBus, UserBus>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
