using TeamPortal.Data;
using Microsoft.EntityFrameworkCore;
using TeamPortal.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeamPortalDbConnection"));
});

builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
