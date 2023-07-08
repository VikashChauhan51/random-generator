

namespace RandomGenerator.Core;
public class Adverb : PartOfSpeech
{
    private readonly List<string> parts = new List<string>();
    public override int Length => parts.Count;
    public Adverb()
    {
        parts.AddRange(new string[] {
    "abnormally",
    "abundantly",
    "absolutely",
    "acceptably",
    "accidentally",
    "accurately",
    "actually",
    "acutely",
    "adorably",
    "adversely",
    "adequately",
    "admirably",
    "admonishingly",
    "adoringly",
    "adroitly",
    "adversarially",
    "affably",
    "affectedly",
    "affordably",
    "agonizingly",
    "aggressively",
    "agonizingly",
    "agreeably",
    "agriculturally",
    "agonizingly",
    "aimlessly",
    "airily",
    "alarmingly",
    "allegedly",
    "alienately",
    "alive",
    "alluringly",
    "almost",
    "alone",
    "along",
    "alphabetically",
    "alterably",
    "ambiguously",
    "amiably",
    "amazingly",
    "ambitiously",
    "amused",
    "amusingly",
    "analytically",
    "angrily",
    "animatedly",
    "annually",
    "another",
    "answerably",
    "antagonistically",
    "anxiously",
    "apathetically",
    "appallingly",
    "appreciably",
    "appropriately",
    "aptly",
    "arrogantly",
    "artistically",
    "ashamedly",
    "aspiringly",
    "assuredly",
    "athletically",
    "attentively",
    "attractively",
    "audaciously",
    "auspiciously",
    "authoritatively"
        });
    }

    public Adverb(IEnumerable<string> nouns)
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
