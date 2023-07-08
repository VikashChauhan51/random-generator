

namespace RandomGenerator.Core;
public class Preposition : PartOfSpeech
{
    private readonly List<string> parts = new List<string>();
    public override int Length => parts.Count;
    public Preposition()
    {
        parts.AddRange(new string[] {
    "about",
    "above",
    "across",
    "after",
    "against",
    "along",
    "among",
    "around",
    "at",
    "before",
    "behind",
    "below",
    "beneath",
    "besides",
    "between",
    "by",
    "down",
    "during",
    "from",
    "in",
    "into",
    "near",
    "of",
    "off",
    "on",
    "onto",
    "opposite",
    "out",
    "outside",
    "over",
    "past",
    "round",
    "since",
    "through",
    "to",
    "toward",
    "under",
    "upon",
    "with",
    "within",
    "without",
    "about",
    "above",
    "across",
    "after",
    "against",
    "along",
    "among",
    "around",
    "at",
    "before",
    "behind",
    "below",
    "beneath",
    "besides",
    "between",
    "by",
    "down",
    "during",
    "from",
    "in",
    "into",
    "near",
    "of",
    "off",
    "on",
    "onto",
    "opposite",
    "out",
    "outside",
    "over",
    "past",
    "round",
    "since",
    "through",
    "to",
    "toward",
    "under",
    "upon",
    "with",
    "within",
    "without"
        });
    }

    public Preposition(IEnumerable<string> nouns)
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
