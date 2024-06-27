using Microsoft.EntityFrameworkCore;
using PersonalPortfolio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PortfolioContext>(
       options => options.UseSqlite("Data Source=ExperienceApi.db"));

builder.Services.AddScoped<ExperienceRepository>();
builder.Services.AddScoped<SkillRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("default");
app.MapControllers();

app.Run();