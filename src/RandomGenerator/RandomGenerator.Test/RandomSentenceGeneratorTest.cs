
namespace RandomGenerator.Test;
public class RandomSentenceGeneratorTest
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(50)]
    [InlineData(100)]
    [InlineData(150)]
    [InlineData(250)]
    [InlineData(500)]
    [InlineData(700)]
    [InlineData(1000)]
    [InlineData(1500)]
    public void Generate_ReturnsStringOfCorrectLength(int length)
    {
        var generator = new RandomSentenceGenerator();
        var result = generator.Generate(length);

        Assert.True(result.Length>= length);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(50)]
    [InlineData(100)]
    [InlineData(150)]
    [InlineData(250)]
    [InlineData(500)]
    [InlineData(700)]
    [InlineData(1000)]
    [InlineData(1500)]
    public void Generate_ReturnsDifferentStringsOnEachCall(int length)
    {
        var generator = new RandomSentenceGenerator();
        var firstResult = generator.Generate(length);
        var secondResult = generator.Generate(length);

        Assert.NotEqual(firstResult, secondResult);
    }
}
