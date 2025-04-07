using apiTurnoMatico.Data;
using Microsoft.EntityFrameworkCore;
using apiTurnoMatico.Services.OficinaService.Interfaces;
using apiTurnoMatico.Services.OficinaService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", policy =>
    {
        string[] allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();
        policy.WithOrigins(allowedOrigins);
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    //options.DefaultApiVersion = new ApiVersion(1, 0);
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddOpenApi();

#region [ Configuracion de Swagger ]
builder.Services.AddSwaggerGen();
#endregion

builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer(configuration.GetConnectionString("default")));

builder.Services.AddScoped<IRepoOficina, RepoOficina>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    #region [ Configuracion de Swagger ]
    app.UseSwagger();
    app.UseSwaggerUI();
    #endregion
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
