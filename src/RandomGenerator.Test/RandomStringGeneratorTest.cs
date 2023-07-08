
using System.Text.RegularExpressions;

namespace RandomGenerator.Test;
public class RandomStringGeneratorTest
{
    [Fact]
    public void GenerateNumberString_ReturnsStringOfCorrectLength()
    {
        // Arrange
        string result;
        int length = 10;

        // Act
        result = new RandomStringGenerator().GenerateNumberString(length);

        // Assert
        Assert.Equal(length, result.Length);
    }
    [Fact]
    public void GenerateNumberString_ReturnsOnlyNumbers()
    {
        // Arrange
        string result;
        int length = 10;

        // Act
        result = new RandomStringGenerator().GenerateNumberString(length);

        // Assert
        Assert.Matches(new Regex("^[0-9]*$"), result);
    }

    [Fact]
    public void GenerateAlphabeticString_ReturnsStringOfCorrectLength()
    {
        // Arrange
        string result;
        int length = 10;

        // Act
        result = new RandomStringGenerator().GenerateAlphabeticString(length);

        // Assert
        Assert.Equal(length, result.Length);
    }

    [Fact]
    public void GenerateNumberString_ReturnsStringOfNumbers()
    {
        var generator = new RandomStringGenerator();
        var result = generator.GenerateNumberString(10);

        Assert.True(result.All(c => char.IsDigit(c)));
    }

    [Fact]
    public void GenerateAlphabeticString_ReturnsStringOfCharacters()
    {
        var generator = new RandomStringGenerator();
        var result = generator.GenerateAlphabeticString(10);

        Assert.True(result.All(c => char.IsLetter(c)));
    }

    [Fact]
    public void GenerateSpecialCharsString_ReturnsStringOfSpecialCharacters()
    {
        var generator = new RandomStringGenerator();
        var result = generator.GenerateSpecialCharsString(10);

        Assert.True(result.All(c => c.IsSpecialChar()));
    }

    [Fact]
    public void GenerateAlphaNumbersString_ReturnsStringOfNumbersAndCharacters()
    {
        var generator = new RandomStringGenerator();
        var result = generator.GenerateAlphaNumbersString(10);

        Assert.True(result.Any(c => char.IsDigit(c)));
        Assert.True(result.Any(c => char.IsLetter(c)));
    }

    [Fact]
    public void GenerateString_ReturnsStringOfAllCharacters()
    {
        var generator = new RandomStringGenerator();
        var result = generator.GenerateString(10);

        Assert.True(result.Any(c => char.IsDigit(c)));
        Assert.True(result.Any(c => char.IsLetter(c)));
        Assert.True(result.Any(c => c.IsSpecialChar()));
    }
 

    [Fact]
    public void GenerateSpecialCharsString_ReturnsStringOfCorrectLength()
    {
        var generator = new RandomStringGenerator();
        var result = generator.GenerateSpecialCharsString(10);

        Assert.True(result.Length == 10);
    }

    [Fact]
    public void GenerateAlphaNumbersString_ReturnsStringOfCorrectLength()
    {
        var generator = new RandomStringGenerator();
        var result = generator.GenerateAlphaNumbersString(10);

        Assert.True(result.Length == 10);
    }

    [Fact]
    public void GenerateString_ReturnsStringOfCorrectLength()
    {
        var generator = new RandomStringGenerator();
        var result = generator.GenerateString(10);

        Assert.True(result.Length == 10);
    }

    [Fact]
    public void GenerateString_ReturnsDifferentStringsOnEachCall()
    {
        var generator = new RandomStringGenerator();
        var firstResult = generator.GenerateString(10);
        var secondResult = generator.GenerateString(10);

        Assert.NotEqual(firstResult, secondResult);
    }
}
