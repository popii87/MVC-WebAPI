using DataAccess.Context;
using DataAccess.Repositories.Classes;
using DataAccess.Repositories.Interfaces;
using DomainModels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoC
{
    public static class IoCContainer
    {
        public static IServiceCollection ConfigureIoCContainer(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
                
            });
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Movie>, MovieRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();
            return services;
        }
    }
}
