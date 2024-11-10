using API.Data;
using API.SignalR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IDbEventRepository, DbEventRepository>();
builder.Services.AddCors();
builder.Services.AddSignalR();

// Register the Background Service
builder.Services.AddHostedService<PeriodicDbEventService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200"));
app.MapControllers();
app.MapHub<DbEventHub>("hubs/dbevents");
app.Run();