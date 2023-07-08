

namespace RandomGenerator.Core;
public class Interjection : PartOfSpeech
{
    private readonly List<string> parts = new List<string>();
    public override int Length => parts.Count;
    public Interjection()
    {
        parts.AddRange(new string[] {
    "Alas!",
    "Aha!",
    "Ahem!",
    "Ahoy!",
    "Bravo!",
    "Bless you!",
    "Crikey!",
    "Drat!",
    "Egad!",
    "Excellent!",
    "Forget it!",
    "Geez!",
    "Gosh!",
    "Gracious!",
    "Heck!",
    "Holy cow!",
    "Holy moly!",
    "Hooray!",
    "Huzzah!",
    "Indeed!",
    "Jeez!",
    "Laugh out loud!",
    "Oh!",
    "Ouch!",
    "Phew!",
    "Please!",
    "Rats!",
    "Shoo!",
    "Shut up!",
    "Shucks!",
    "Shiver me timbers!",
    "So long!",
    "Stop!",
    "Wow!",
    "Yikes!",
    "You bet!",
    "You're welcome!"
        });
    }

    public Interjection(IEnumerable<string> nouns)
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
