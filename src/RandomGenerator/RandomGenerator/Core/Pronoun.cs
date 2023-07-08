

namespace RandomGenerator.Core;

public class Pronoun : PartOfSpeech
{
    private readonly List<string> parts = new List<string>();
    public override int Length => parts.Count;
    public Pronoun()
    {
        parts.AddRange(new string[] {
    "I",
    "you",
    "he",
    "she",
    "it",
    "we",
    "they",
    "me",
    "you",
    "him",
    "her",
    "it",
    "us",
    "them",
    "mine",
    "yours",
    "his",
    "hers",
    "its",
    "ours",
    "theirs",
    "this",
    "that",
    "these",
    "those",
    "who",
    "whom",
    "whose",
    "which",
    "what",
    "whoever",
    "whomever",
    "whosever",
    "whichever",
    "whatever",
    "myself",
    "yourself",
    "himself",
    "herself",
    "itself",
    "ourselves",
    "yourselves",
    "themselves",
    "anybody",
    "anyone",
    "anything",
    "each",
    "either",
    "everybody",
    "everyone",
    "everything",
    "few",
    "many",
    "neither",
    "nobody",
    "no one",
    "nothing",
    "other",
    "somebody",
    "someone",
    "something",
    "such",
    "that",
    "this",
    "those",
    "what",
    "who",
    "whom"
        });
    }

    public Pronoun(IEnumerable<string> nouns)
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
