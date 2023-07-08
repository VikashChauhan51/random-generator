
namespace RandomGenerator.Core;
public class Adjective : PartOfSpeech
{
    private readonly List<string> parts = new List<string>();
    public override int Length => parts.Count;
    public Adjective()
    {
        parts.AddRange(new string[] {
    "able",
    "abundant",
    "accepting",
    "accurate",
    "amused",
    "amusing",
    "angelic",
    "angry",
    "animated",
    "annoyed",
    "antagonistic",
    "anxious",
    "apathetic",
    "approving",
    "apt",
    "aquatic",
    "ardent",
    "argumentative",
    "aristocratic",
    "artificial",
    "artistic",
    "ashamed",
    "aspiring",
    "assured",
    "athletic",
    "attentive",
    "attractive",
    "average",
    "awake",
    "awful",
    "bad",
    "balanced",
    "bare",
    "beautiful",
    "bewildered",
    "big",
    "bitter",
    "black",
    "blank",
    "bleak",
    "blond",
    "bloody",
    "blue",
    "bold",
    "boring",
    "brave",
    "brawny",
    "bright",
    "brilliant",
    "broad",
    "broken",
    "brown",
    "bruised",
    "bubbly",
    "busy",
    "calm",
    "careful",
    "casual",
    "cautious",
    "certain",
    "chubby",
    "clever",
    "cloudy",
    "cold",
    "colorful",
    "comfortable",
    "comical",
    "common",
    "complete",
    "composed",
    "concerned",
    "confident",
    "confused",
    "conscious",
    "considerate",
    "constant",
    "content",
    "continuing",
    "cool",
    "correct",
    "courageous",
    "crazy",
    "creative",
    "critical",
    "crowded",
    "cruel",
    "curious",
    "curved",
    "cynical"
        });
    }

    public Adjective(IEnumerable<string> nouns)
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
