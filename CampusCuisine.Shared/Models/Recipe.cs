using System.ComponentModel.DataAnnotations;

namespace CampusCuisine.Shared.Models;

public class Recipe
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string Name { get; set; } = "";

    [Required]
    public string Category { get; set; } = "";

    [Required]
    [StringLength(300)]
    public string Ingredients { get; set; } = "";

    [Required]
    [StringLength(1000)]
    public string Instructions { get; set; } = "";
}
