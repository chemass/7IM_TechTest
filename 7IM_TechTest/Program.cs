using _7IM_TechTest.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("VaryBySearchTerm", builder => builder.SetVaryByRouteValue("searchTerm"));
});

builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/search/{searchTerm:alpha}", async (string? searchTerm, IPersonRepository repo) =>
{
    if (string.IsNullOrWhiteSpace(searchTerm))
        return Results.ValidationProblem(new Dictionary<string, string[]>
        { { nameof(searchTerm), ["This field cannot be empty."] } });

    var results = await repo.Find(searchTerm!);
    return Results.Ok(results);
})
.WithName("SearchUsers")
.WithOpenApi()
.CacheOutput("VaryBySearchTerm")
.ProducesValidationProblem();

app.Run();
