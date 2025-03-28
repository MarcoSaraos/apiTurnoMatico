var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region [ Configuracion de Swagger ]
builder.Services.AddSwaggerGen();
#endregion
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
