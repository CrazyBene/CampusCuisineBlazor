using System.Collections.Concurrent;
using CampusCuisine.Shared.Models;

namespace CampusCuisine.Api.Data;

public class RecipeStore
{
    public List<Recipe> Recipes { get; } =
    [
        new()
        {
            Id = Guid.Parse("3b0c7a52-6f1e-4c8e-9a41-1d2f5e8b7c01"),
            Name = "Spaghetti Carbonara",
            Category = "Pasta",
            Ingredients = "Spaghetti, eggs, bacon, parmesan, pepper",
            Instructions = "Cook the spaghetti. Fry the bacon. Mix eggs and parmesan, stir everything together off the heat."
        },
        new()
        {
            Id = Guid.Parse("8e4d2f19-0a6b-4b7d-8c3e-5f9a1b2c3d02"),
            Name = "Overnight Oats",
            Category = "Breakfast",
            Ingredients = "Oats, milk, yogurt, honey, berries",
            Instructions = "Mix oats, milk, yogurt and honey. Leave in the fridge overnight, top with berries."
        },
        new()
        {
            Id = Guid.Parse("c1f5e8a3-2d7b-4e9c-a6f0-7b8c9d0e1f03"),
            Name = "Chili sin Carne",
            Category = "Stew",
            Ingredients = "Kidney beans, corn, tomatoes, onion, chili, cumin",
            Instructions = "Fry the onion, add everything else and let it simmer for 30 minutes."
        },
        new()
        {
            Id = Guid.Parse("5a9b3c7d-1e2f-4a6b-9c8d-0e1f2a3b4c04"),
            Name = "Fried Rice",
            Category = "Rice",
            Ingredients = "Rice from yesterday, eggs, peas, carrots, soy sauce",
            Instructions = "Scramble the eggs, add vegetables and rice, season with soy sauce."
        },
        new()
        {
            Id = Guid.Parse("f2e1d0c9-8b7a-4c6d-b5e4-3f2a1b0c9d05"),
            Name = "Tomato Soup",
            Category = "Soup",
            Ingredients = "Tomatoes, onion, garlic, vegetable stock, basil",
            Instructions = "Fry onion and garlic, add tomatoes and stock, simmer and blend."
        }
    ];

    public ConcurrentDictionary<Guid, int> Ratings { get; } = [];
}
