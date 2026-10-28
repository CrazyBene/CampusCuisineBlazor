using CampusCuisine.Client.Pages;
using CampusCuisine.Client.Services;
using CampusCuisine.Shared.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CampusCuisine.Client.Tests;

public class RecipesPageTests : BunitContext
{
    public RecipesPageTests()
    {
        List<Recipe> recipes =
        [
            new() { Name = "Spaghetti Carbonara", Category = "Pasta", Ingredients = "Spaghetti, eggs" },
            new() { Name = "Tomato Soup", Category = "Soup", Ingredients = "Tomatoes, onion" }
        ];

        var http = new HttpClient(new FakeApiHandler(recipes)) { BaseAddress = new Uri("http://localhost/") };
        Services.AddSingleton(http);
        Services.AddScoped<RecipeService>();
        Services.AddLocalization();
    }

    [Fact]
    public void ShowsAllRecipes()
    {
        // Arrange
        var cut = Render<Recipes>();

        // Assert
        cut.WaitForAssertion(() => Assert.Equal(2, cut.FindAll(".recipe-card").Count));
    }

    [Fact]
    public void SearchFiltersRecipes()
    {
        // Arrange
        var cut = Render<Recipes>();
        cut.WaitForAssertion(() => Assert.Equal(2, cut.FindAll(".recipe-card").Count));

        // Act
        cut.Find("input").Input("soup");

        // Assert
        var card = Assert.Single(cut.FindAll(".recipe-card"));
        Assert.Contains("Tomato Soup", card.TextContent);
    }
}
