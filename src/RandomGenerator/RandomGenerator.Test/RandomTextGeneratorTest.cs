
namespace RandomGenerator.Test;
public class RandomTextGeneratorTest
{
    [Theory]
    [InlineData(3, 2, 5, 5, 10)]
    [InlineData(3, 2, 5, 3, 10)]
    [InlineData(5, 2, 5, 5, 10)]
    [InlineData(3, 2, 9, 6, 10)]
    [InlineData(3, 2, 7, 5, 10)]
    [InlineData(3, 2, 3, 5, 10)]
    [InlineData(5, 2, 7, 5, 10)]
    [InlineData(7, 2, 5, 5, 10)]
    [InlineData(10, 2, 5, 5, 10)]
    [InlineData(7, 2, 5, 9, 10)]
    public void Generate_ReturnsStringOfCorrectLength(int numberParagraphs, int minSentences,
        int maxSentences, int minWords, int maxWords)
    {
        var generator = new RandomTextGenerator();
        var result = generator.Generate(numberParagraphs, minSentences, maxSentences, minWords, maxWords);

        var paragraphCount = result.Split("\n\n", StringSplitOptions.RemoveEmptyEntries).Count();
        Assert.Equal(numberParagraphs, paragraphCount);
    }

    [Fact]
    public void Generate_ReturnsDifferentStringsOnEachCall()
    {
        var generator = new RandomTextGenerator();
        var firstResult = generator.Generate(3, 2, 5, 5, 10);
        var secondResult = generator.Generate(3, 2, 5, 5, 10);

        Assert.NotEqual(firstResult, secondResult);
    }

    [Fact]
    public void Generate_IncludesThreeParagraphs()
    {
        var generator = new RandomTextGenerator();
        var result = generator.Generate(3, 2, 5, 5, 10);
        Assert.Contains("\n\n", result);
        var paragraphCount = result.Split("\n\n").Count() - 1;
        Assert.Equal(3, paragraphCount);
    }

    [Theory]
    [InlineData(3, 2, 5, 5, 10)]
    [InlineData(10, 2, 5, 5, 10)]
    [InlineData(7, 2, 5, 5, 10)]
    [InlineData(3, 2, 5, 6, 10)]
    [InlineData(9, 2, 5, 5, 10)]
    [InlineData(3, 2, 3, 5, 10)]
    [InlineData(5, 2, 5, 5, 10)]
    [InlineData(7, 2, 5, 3, 10)]
    [InlineData(10, 2, 9, 5, 10)]
    [InlineData(7, 2, 5, 9, 10)]
    public void Generate_IncludesParagraphsOfCorrectLength(int numberParagraphs, int minSentences,
        int maxSentences, int minWords, int maxWords)
    {
        var generator = new RandomTextGenerator();
        var result = generator.Generate(numberParagraphs, minSentences, maxSentences, minWords, maxWords);

        var paragraphs = result.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < numberParagraphs; i++)
        {
            var sentenceCount = paragraphs[i].Split(".", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Count();
            Assert.True(sentenceCount >= minSentences && sentenceCount <= maxSentences);
        }
    }

}
