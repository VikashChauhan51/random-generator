
namespace RandomGenerator.Test;
public class RandomPasswordGeneratorTest
{

    [Fact]
    public void Generate_ReturnsStringOfCorrectLength()
    {
        var generator = new RandomPasswordGenerator();
        var result = generator.Generate(10);

        Assert.True(result.Length == 10);
    }

    [Fact]
    public void Generate_ReturnsDifferentStringsOnEachCall()
    {
        var generator = new RandomPasswordGenerator();
        var firstResult = generator.Generate(10);
        var secondResult = generator.Generate(10);

        Assert.NotEqual(firstResult, secondResult);
    }

    [Fact]
    public void Generate_IncludesLowercaseCharacters()
    {
        var generator = new RandomPasswordGenerator().IncludeLowercase(true);
        var result = generator.Generate(10);

        Assert.True(result.Any(c => char.IsLower(c)));
    }

    [Fact]
    public void Generate_IncludesUppercaseCharacters()
    {
        var generator = new RandomPasswordGenerator().IncludeUppercase(true);
        var result = generator.Generate(10);

        Assert.True(result.Any(c => char.IsUpper(c)));
    }

    [Fact]
    public void Generate_IncludesNumericCharacters()
    {
        var generator = new RandomPasswordGenerator().IncludeNumeric(true);
        var result = generator.Generate(10);

        Assert.True(result.Any(c => char.IsDigit(c)));
    }

    [Fact]
    public void Generate_IncludesSpecialCharacters()
    {
        var generator = new RandomPasswordGenerator().IncludeSpecial(true);
        var result = generator.Generate(10);

        Assert.True(result.Any(c => c.IsSpecialChar()));
    }

    [Fact]
    public void Generate_DoesNotIncludeLowercaseCharacters_WhenSetToFalse()
    {
        var generator = new RandomPasswordGenerator().IncludeLowercase(false);
        var result = generator.Generate(10);

        Assert.True(!result.Any(c => char.IsLower(c)));
    }

    [Fact]
    public void Generate_DoesNotIncludeUppercaseCharacters_WhenSetToFalse()
    {
        var generator = new RandomPasswordGenerator().IncludeUppercase(false);
        var result = generator.Generate(10);

        Assert.True(!result.Any(c => char.IsUpper(c)));
    }

    [Fact]
    public void Generate_DoesNotIncludeNumericCharacters_WhenSetToFalse()
    {
        var generator = new RandomPasswordGenerator().IncludeNumeric(false);
        var result = generator.Generate(10);

        Assert.True(!result.Any(c => char.IsDigit(c)));
    }

    [Fact]
    public void Generate_DoesNotIncludeSpecialCharacters_WhenSetToFalse()
    {
        var generator = new RandomPasswordGenerator().IncludeSpecial(false);
        var result = generator.Generate(10);

        Assert.True(!result.Any(c => c.IsSpecialChar()));
    }
}
