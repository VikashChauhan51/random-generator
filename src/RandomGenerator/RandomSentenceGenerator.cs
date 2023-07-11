using RandomGenerator.Core;

namespace RandomGenerator;

public class RandomSentenceGenerator
{

    private Operations operations = Operations.None;
    private PartOfSpeech verbs;
    private PartOfSpeech adjectives;
    private PartOfSpeech adverbs;
    private PartOfSpeech nouns;
    private PartOfSpeech pronouns;
    private PartOfSpeech prepositions;
    private PartOfSpeech conjunctions;
    private PartOfSpeech interjections;

    public RandomSentenceGenerator()
    {
        verbs = new Verb();
        adjectives = new Adjective();
        adverbs = new Adverb();
        nouns = new Noun();
        pronouns = new Pronoun();
        prepositions = new Preposition();
        conjunctions = new Conjunction();
        interjections = new Interjection();

        IncludeOperation(Operations.Subject);
        IncludeOperation(Operations.Verb);
        IncludeOperation(Operations.Object);
        IncludeOperation(Operations.Adjective);
        IncludeOperation(Operations.Preposition);
        IncludeOperation(Operations.Adverb);
        IncludeOperation(Operations.Conjunction);
        IncludeOperation(Operations.Interjections);
    }
    public RandomSentenceGenerator(PartOfSpeech verbs,
        PartOfSpeech adjectives,
        PartOfSpeech adverbs,
        PartOfSpeech nouns,
        PartOfSpeech pronouns,
        PartOfSpeech prepositions,
        PartOfSpeech conjunctions,
        PartOfSpeech interjections)
    {
        this.verbs = verbs ?? new Verb();
        this.adjectives = adjectives ?? new Adjective();
        this.adverbs = adverbs ?? new Adverb();
        this.nouns = nouns ?? new Noun();
        this.pronouns = pronouns ?? new Pronoun();
        this.prepositions = prepositions ?? new Preposition();
        this.conjunctions = conjunctions ?? new Conjunction();
        this.interjections = interjections ?? new Interjection();

    }

    public RandomSentenceGenerator With(Noun nouns)
    {
        this.nouns = nouns ?? new Noun();
        return this;
    }
    public RandomSentenceGenerator With(Pronoun pronouns)
    {
        this.pronouns = pronouns ?? new Pronoun();
        return this;
    }
    public RandomSentenceGenerator With(Verb verbs)
    {
        this.verbs = verbs ?? new Verb();
        return this;
    }
    public RandomSentenceGenerator With(Adjective adjectives)
    {
        this.adjectives = adjectives ?? new Adjective();
        return this;
    }
    public RandomSentenceGenerator With(Adverb adverbs)
    {
        this.adverbs = adverbs ?? new Adverb();
        return this;
    }
    public RandomSentenceGenerator With(Preposition prepositions)
    {
        this.prepositions = prepositions ?? new Preposition();
        return this;
    }
    public RandomSentenceGenerator With(Conjunction conjunctions)
    {
        this.conjunctions = conjunctions ?? new Conjunction();
        return this;
    }
    public RandomSentenceGenerator With(Interjection interjections)
    {
        this.interjections = interjections ?? new Interjection();
        return this;
    }
    public RandomSentenceGenerator IncludeOperation(Operations operation)
    {
        operations |= operation;
        return this;
    }
    public RandomSentenceGenerator ExcludeOperation(Operations operation)
    {
        operations &= ~operation;
        return this;
    }
    public string Generate(int wordsCount)
    {
        var partOfSpeechs = GetPartsOfSpeech();
        var partOfSpeechsTypes = Enum.GetValues<Operations>();
        var words = new List<string>();

        var count = 1;
        for (var i = 0; i < wordsCount; i++)
        {
            if (count >= partOfSpeechsTypes.Length)
                count = 1;

            // the output words count may be mishmatch due to this.
            var operation = partOfSpeechsTypes.Skip(count).First();
            if ((operations & operation) == operation)
            {
                var input = partOfSpeechs[operation]();
                words.Add(i == 0 ?
                    string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1)) :
                    partOfSpeechs[operation]());

            }
            else
            {
                //add random word
                words.Add(partOfSpeechs[partOfSpeechsTypes.Last()]());

            }

            count++;
        }

        return string.Join(" ", words);
    }

    private Dictionary<Operations, Func<string>> GetPartsOfSpeech()
    {
        return new Dictionary<Operations, Func<string>>
        {
            [Operations.Subject] = nouns.GetRandomPart,
            [Operations.Verb] = verbs.GetRandomPart,
            [Operations.Object] = pronouns.GetRandomPart,
            [Operations.Adjective] = adjectives.GetRandomPart,
            [Operations.Adverb] = adverbs.GetRandomPart,
            [Operations.Preposition] = prepositions.GetRandomPart,
            [Operations.Conjunction] = conjunctions.GetRandomPart,
            [Operations.Interjections] = interjections.GetRandomPart
        };
    }
}
