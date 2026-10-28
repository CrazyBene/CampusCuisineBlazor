using CampusCuisine.Api.Data;
using CampusCuisine.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<RecipeStore>();
builder.Services.AddValidation();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy
    .WithOrigins("http://localhost:5100", "https://localhost:7100")
    .AllowAnyHeader()
    .AllowAnyMethod()));

var app = builder.Build();

app.UseCors();

app.MapGet("/recipes", (RecipeStore store) => store.Recipes);

app.MapGet("/recipes/{id:guid}", (Guid id, RecipeStore store) =>
    store.Recipes.FirstOrDefault(r => r.Id == id) is { } recipe
        ? Results.Ok(recipe)
        : Results.NotFound());

app.MapPost("/recipes", (Recipe recipe, RecipeStore store) =>
{
    recipe.Id = Guid.NewGuid();
    store.Recipes.Add(recipe);
    return Results.Created($"/recipes/{recipe.Id}", recipe);
});

app.MapGet("/recipes/{id:guid}/rating", (Guid id, RecipeStore store) =>
    new Rating { Stars = store.Ratings.GetValueOrDefault(id) });

app.MapPut("/recipes/{id:guid}/rating", (Guid id, Rating rating, RecipeStore store) =>
{
    if (store.Recipes.All(r => r.Id != id))
    {
        return Results.NotFound();
    }

    store.Ratings[id] = rating.Stars;
    return Results.NoContent();
});

app.Run();
