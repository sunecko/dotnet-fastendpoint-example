using Example.Api.Configurations;
using Example.Application.Configurations;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;

var bld = WebApplication.CreateBuilder();


bld.Services.AddApplicationSetup()
    .AddFastEndpointSetup()
    .AddAuthorization()
    .AddSwaggerSetup()
    .AddPersistenceSetup(bld.Configuration)
    .AddSecuritySetup(bld.Configuration);

var app = bld.Build();

app.UseFastEndpoints()
    .UseSwaggerGen()
    .UseAuthentication()
    .UseAuthorization()
    .ApplicationServices.ApplyMigrations();

app.Run();