
namespace RandomGenerator.Core;
public class Conjunction : PartOfSpeech
{
    private readonly List<string> parts = new List<string>();
    public override int Length => parts.Count;
    public Conjunction()
    {
        parts.AddRange(new string[] {
    "and",
    "but",
    "or",
    "nor",
    "for",
    "yet",
    "so",
    "because",
    "although",
    "though",
    "while",
    "since",
    "as",
    "if",
    "when",
    "where",
    "whenever",
    "wherever",
    "until",
    "unless",
    "whether",
    "that",
    "which",
    "who",
    "whom",
    "whose",
    "what",
    "whatever",
    "whichever",
    "whereas",
    "while",
    "hence",
    "therefore",
    "so",
    "consequently",
    "thus",
    "also",
    "furthermore",
    "moreover",
    "besides",
    "instead",
    "rather",
    "otherwise",
    "yet",
    "still",
    "nevertheless",
    "however",
    "though",
    "although",
    "even though",
    "in spite of",
    "despite",
    "whether",
    "if",
    "only",
    "save",
    "except",
    "unless",
    "lest",
    "provided",
    "granted",
    "assuming",
    "supposing"
        });
    }

    public Conjunction(IEnumerable<string> nouns)
    {
        parts.AddRange(nouns);
    }
    public override string GetPart(int index) => parts[index];
    public override IEnumerable<string> GetParts() => parts.ToList();

    public override string GetRandomPart()
    {
        var index = random.Next(0, parts.Count);
        return GetPart(index);
    }
}
