using Domain.Interfaces.Services;
using Service.Services;
using Service.Implementations;
using Domain.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISimianService, SimianService>();
builder.Services.AddScoped<ISimianPatternsExecute, SimianPatternsExecute>();

builder.Services.AddScoped<SimianPatternAbstract, DiagonalSimianPattern>();
builder.Services.AddScoped<SimianPatternAbstract, HorizontalSimianPattern>();
builder.Services.AddScoped<SimianPatternAbstract, VerticalSimianPattern>();
//builder.Services.AddScoped<ISimianPattern>(sp => sp.GetRequiredService<SimianPatternAbstract>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
