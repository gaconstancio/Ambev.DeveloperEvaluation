﻿using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Infrastructure.Data;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
    }
}