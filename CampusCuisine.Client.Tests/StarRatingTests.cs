using CampusCuisine.Client.Components;
using Microsoft.Extensions.DependencyInjection;

namespace CampusCuisine.Client.Tests;

public class StarRatingTests : BunitContext
{
    public StarRatingTests()
    {
        // Every component injects IStringLocalizer (see _Imports.razor)
        Services.AddLocalization();
    }

    [Fact]
    public void ShowsFilledStarsUpToValue()
    {
        // Arrange
        var cut = Render<StarRating>(parameters => parameters
            .Add(p => p.Value, 3));

        // Assert
        Assert.Equal(5, cut.FindAll(".star").Count);
        Assert.Equal(3, cut.FindAll(".star.filled").Count);
    }

    [Fact]
    public void ClickOnStarReportsNewValue()
    {
        // Arrange
        var reportedValue = 0;
        var cut = Render<StarRating>(parameters => parameters
            .Add(p => p.Value, 1)
            .Add(p => p.ValueChanged, value => reportedValue = value));

        // Act
        cut.FindAll(".star")[3].Click();

        // Assert
        Assert.Equal(4, reportedValue);
    }
}
