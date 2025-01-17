using JobList.Data;
using Microsoft.EntityFrameworkCore;
using JobList.Repository;
using JobList.Interfaces;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Database connection
    string dbConnectionString;
    if (builder.Environment.IsDevelopment())
    {
        dbConnectionString = DotNetEnv.Env.GetString("SQL_LITE_DB_PATH")
                             ?? throw new InvalidOperationException(
                                 "SQL_LITE_DB_PATH is not set.");
        builder.Services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlite(dbConnectionString));
    }
    else
    {
        dbConnectionString = DotNetEnv.Env.GetString("SQL_SERVER_DB_CONNECTION")
                             ?? throw new InvalidOperationException(
                                 "SQL_SERVER_DB_CONNECTION is not set.");
        builder.Services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(dbConnectionString));
    }

    // Registering the repository
    builder.Services.AddScoped<IJopPostRepo, JopPostRepo>();
}


var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
