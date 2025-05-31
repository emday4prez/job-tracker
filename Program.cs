using JobTrackerApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JobDbContext>(options =>
    options.UseSqlite("Data Source=jobs.db"));

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();