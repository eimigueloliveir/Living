﻿using Living.Domain.Base.Interfaces;
using Living.Domain.Entities.Posts.Interface;
using Living.Infraestructure.Repositories;
using Living.Infraestructure.UnitOfWorks;

namespace Living.WebAPI.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPostsRepository, PostsRepository>();

        return services;
    }
}
