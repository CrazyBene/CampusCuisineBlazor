using System.ComponentModel.DataAnnotations;

namespace CampusCuisine.Shared.Models;

public class Rating
{
    [Range(1, 5)]
    public int Stars { get; set; }
}
