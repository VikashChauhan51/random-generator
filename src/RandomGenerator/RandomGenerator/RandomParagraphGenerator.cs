namespace RandomGenerator;
public class RandomParagraphGenerator
{
    private readonly RandomSentenceGenerator sentenceGenerator;
    protected static readonly Random random = new();
    public RandomParagraphGenerator() : this(null)
    {

    }
    public RandomParagraphGenerator(RandomSentenceGenerator? sentenceGenerator)
    {
        this.sentenceGenerator = sentenceGenerator ?? new RandomSentenceGenerator();
    }

    public string Generate(int numberSentences, int minWords, int maxWords)
    {
        var sentences = new List<string>();
        for (var i = 0; i < numberSentences; i++)
        {
            sentences.Add(sentenceGenerator.Generate(random.Next(minWords, maxWords)));
        }

        return string.Concat(string.Join(". ", sentences), ".");
    }
}
