
namespace RandomGenerator.Core;

public class Verb : PartOfSpeech
{
    private readonly List<string> parts = new List<string>();
    public override int Length => parts.Count;
    public Verb()
    {
        parts.AddRange(new string[] {
    "abash",
    "abate",
    "abide",
    "absorb",
    "abuse",
    "accept",
    "access",
    "accelerate",
    "accentuate",
    "accept",
    "access",
    "accelerate",
    "accentuate",
    "acclaim",
    "acclimate",
    "accumulate",
    "accuracy",
    "accustom",
    "achieve",
    "acidify",
    "acknowledge",
    "acquire",
    "across",
    "act",
    "action",
    "activate",
    "activity",
    "actor",
    "actress",
    "ad",
    "adapt",
    "add",
    "address",
    "adequate",
    "adjective",
    "administer",
    "admire",
    "admit",
    "adopt",
    "adolescence",
    "adult",
    "advance",
    "advantage",
    "adventurous",
    "advertise",
    "advice",
    "advise",
    "advocate",
    "affect",
    "affect",
    "affiliate",
    "affinity",
    "afford",
    "afraid",
    "after",
    "afternoon",
    "again",
    "against",
    "age",
    "agent",
    "agree",
    "agreement",
    "agriculture",
    "ahead",
    "aim",
    "air",
    "airplane",
    "aisle",
    "alarm",
    "album",
    "alcohol",
    "alien",
    "allergic",
    "allow",
    "allude",
    "almost",
    "alone",
    "along",
    "aloud",
    "alphabet",
    "alter",
    "altitude",
    "although",
    "always",
    "am",
    "amateur",
    "amazing",
    "among",
    "amount",
    "amused",
    "analyze",
    "ancient",
    "and",
    "angel",
    "anger",
    "angle",
    "angry",
    "animal",
    "ankle",
    "announce",
    "annual",
    "another",
    "answer",
    "ant",
    "antagonize",
    "anxious",
    "apartment",
    "appear",
    "appearance",
    "appeal",
    "appear"

        });
    }

    public Verb(IEnumerable<string> nouns)
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
