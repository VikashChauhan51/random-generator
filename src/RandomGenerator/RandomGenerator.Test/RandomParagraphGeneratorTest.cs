
namespace RandomGenerator.Test;
public class RandomParagraphGeneratorTest
{
    [Theory]
    [InlineData(3, 5, 10)]
    [InlineData(3, 8, 10)]
    [InlineData(3, 7, 10)]
    [InlineData(3, 9, 10)]
    [InlineData(5, 5, 10)]
    [InlineData(2, 5, 10)]
    [InlineData(1, 5, 10)]
    [InlineData(9, 5, 10)]
    [InlineData(4, 5, 10)]
    [InlineData(3, 9, 15)]
    [InlineData(7, 7, 19)]
    public void Generate_ReturnsStringOfCorrectLength(int numberSentences, int minWords, int maxWords)
    {
        var generator = new RandomParagraphGenerator();
        var result = generator.Generate(numberSentences, minWords, maxWords);
        var sentenceCount = result.Split(". ").Count();
        Assert.Equal(numberSentences, sentenceCount);
    }

    [Fact]
    public void Generate_ReturnsDifferentStringsOnEachCall()
    {
        var generator = new RandomParagraphGenerator();
        var firstResult = generator.Generate(3, 5, 10);
        var secondResult = generator.Generate(3, 5, 10);

        Assert.NotEqual(firstResult, secondResult);
    }

    [Fact]
    public void Generate_IncludesThreeSentences()
    {
        var generator = new RandomParagraphGenerator();
        var result = generator.Generate(3, 5, 10);

        var count = result.Split(". ").Count() - 1;
        Assert.Contains(". ", result);
        Assert.Equal(2, count);
    }

    [Theory]
    [InlineData(3, 5, 10)]
    [InlineData(3, 8, 10)]
    [InlineData(3, 7, 10)]
    [InlineData(3, 9, 10)]
    [InlineData(5, 5, 10)]
    [InlineData(2, 5, 10)]
    [InlineData(1, 5, 10)]
    [InlineData(9, 5, 10)]
    [InlineData(4, 5, 10)]
    [InlineData(3, 9, 15)]
    [InlineData(7, 7, 19)]
    public void Generate_IncludesSentencesOfCorrectLength(int numberSentences, int minWords, int maxWords)
    {
        int min = minWords - 1;
        int max = maxWords + 1;
        var generator = new RandomParagraphGenerator();
        var result = generator.Generate(numberSentences, minWords, maxWords);

        var sentences = result.Split(".", StringSplitOptions.RemoveEmptyEntries);
        for (var i = 0; i < numberSentences; i++)
        {
            var sentence = sentences[i].Trim();
            var words = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries).Count();
            Assert.True(words >= min && words <= max);
        }
    }
}
