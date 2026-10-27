using CampusCuisine.Client.Models;

namespace CampusCuisine.Client.Data;

public static class SampleRecipes
{
    public static readonly List<Recipe> All =
    [
        new()
        {
            Id = 1,
            Name = "Spaghetti Carbonara",
            Category = "Pasta",
            Ingredients = "Spaghetti, eggs, bacon, parmesan, pepper",
            Instructions = "Cook the spaghetti. Fry the bacon. Mix eggs and parmesan, stir everything together off the heat."
        },
        new()
        {
            Id = 2,
            Name = "Overnight Oats",
            Category = "Breakfast",
            Ingredients = "Oats, milk, yogurt, honey, berries",
            Instructions = "Mix oats, milk, yogurt and honey. Leave in the fridge overnight, top with berries."
        },
        new()
        {
            Id = 3,
            Name = "Chili sin Carne",
            Category = "Stew",
            Ingredients = "Kidney beans, corn, tomatoes, onion, chili, cumin",
            Instructions = "Fry the onion, add everything else and let it simmer for 30 minutes."
        },
        new()
        {
            Id = 4,
            Name = "Fried Rice",
            Category = "Rice",
            Ingredients = "Rice from yesterday, eggs, peas, carrots, soy sauce",
            Instructions = "Scramble the eggs, add vegetables and rice, season with soy sauce."
        },
        new()
        {
            Id = 5,
            Name = "Tomato Soup",
            Category = "Soup",
            Ingredients = "Tomatoes, onion, garlic, vegetable stock, basil",
            Instructions = "Fry onion and garlic, add tomatoes and stock, simmer and blend."
        }
    ];
}
