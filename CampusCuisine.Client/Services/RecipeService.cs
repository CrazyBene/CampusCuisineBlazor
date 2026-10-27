using System.Net;
using System.Net.Http.Json;
using CampusCuisine.Shared.Models;

namespace CampusCuisine.Client.Services;

public class RecipeService(HttpClient http)
{
    public async Task<List<Recipe>> GetRecipesAsync()
    {
        return await http.GetFromJsonAsync<List<Recipe>>("recipes") ?? [];
    }

    public async Task<Recipe?> GetRecipeAsync(Guid id)
    {
        var response = await http.GetAsync($"recipes/{id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Recipe>();
    }

    public async Task<int> GetRatingAsync(Guid recipeId)
    {
        var rating = await http.GetFromJsonAsync<Rating>($"recipes/{recipeId}/rating");
        return rating?.Stars ?? 0;
    }

    public async Task RateAsync(Guid recipeId, int stars)
    {
        var response = await http.PutAsJsonAsync($"recipes/{recipeId}/rating", new Rating { Stars = stars });
        response.EnsureSuccessStatusCode();
    }
}
