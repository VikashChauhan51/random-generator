
namespace RandomGenerator.Core;

public abstract class PartOfSpeech
{
    protected static readonly Random random = new();
    public abstract int Length { get; }
    public abstract IEnumerable<string> GetParts();
    public abstract string GetPart(int index);
    public abstract string GetRandomPart();
}
