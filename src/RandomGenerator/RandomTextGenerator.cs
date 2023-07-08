using System.Text;

namespace RandomGenerator;

public class RandomTextGenerator
{
    protected static readonly Random random = new();

    private readonly RandomParagraphGenerator randomParagraphGenerator;
    public RandomTextGenerator() : this(null)
    {
    }
    public RandomTextGenerator(RandomParagraphGenerator? randomParagraphGenerator)
    {
        this.randomParagraphGenerator = randomParagraphGenerator ?? new RandomParagraphGenerator();
    }

    public string Generate(int numberParagraphs, int minSentences,
        int maxSentences, int minWords, int maxWords)
    {
        var builder = new StringBuilder();
        for (var i = 0; i < numberParagraphs; i++)
        {
            builder.Append(randomParagraphGenerator.Generate(random.Next(minSentences, maxSentences + 1), minWords, maxWords));
            builder.Append("\n\n");
        }

        return builder.ToString();
    }
}
