using Microsoft.EntityFrameworkCore;
using postsAPI.Data;

using postsAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//db 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//mapper 
builder.Services.AddAutoMapper(profileAssemblyMarkerTypes: typeof(Mappings));


builder.Services.AddScoped<IPostRepository, IPostSql>();
builder.Services.AddScoped<IAuthRepository,SQLauthRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
