using Microsoft.EntityFrameworkCore;
using TrackingTasks.Interfaces.Repositories;
using TrackingTasks.Interfaces.Services;
using TrackingTasks.Models;
using TrackingTasks.Repositories;
using TrackingTasks.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WorkTaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WorkTaskDbContext")),
    contextLifetime: ServiceLifetime.Transient,
    optionsLifetime: ServiceLifetime.Transient);


builder.Services.AddScoped<IWorkTaskService, WorkTaskService>();
builder.Services.AddScoped<IWorkTaskRepository, WorkTaskRepository>();


var app = builder.Build();
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
