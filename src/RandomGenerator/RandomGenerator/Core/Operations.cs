
namespace RandomGenerator.Core;

[Flags]
public enum Operations
{
    None = 0,
    Subject = 1,
    Verb = 2,
    Object = 4,
    Adjective = 8,
    Adverb = 16,
    Preposition = 32,
    Conjunction = 64,
    Interjections = 128
}
