using Microsoft.EntityFrameworkCore;
using PersonalPortfolio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(
       options => options.UseSqlite("Data Source=.;Initial Catalog=PortfolioDb;Integrated Security=True;"));

builder.Services.AddCors(options =>
{
    
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
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