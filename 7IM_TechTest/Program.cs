using _7IM_TechTest.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/search", async (string? searchTerm, [FromServices] IPersonRepository repo) =>
{
    if (string.IsNullOrWhiteSpace(searchTerm))
        return Results.ValidationProblem(new Dictionary<string, string[]>
        { { nameof(searchTerm), ["Cannot be empty."] } });

    var results = await repo.Find(searchTerm!);
    return Results.Ok(results);
})
.WithName("SearchUsers")
.WithOpenApi()
.ProducesValidationProblem();

app.Run();
