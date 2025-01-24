namespace RandomGenerator;
public interface IIdGenerator
{
    long CreateId();
    bool TryCreateId(out long id);
}


public record struct Id
{
    
    public int SequenceNumber { get; private set; }


    public int GeneratorId { get; private set; }

    public DateTimeOffset DateTimeOffset { get; private set; }


    internal Id(int sequenceNumber, int generatorId, DateTimeOffset dateTimeOffset)
    {
        SequenceNumber = sequenceNumber;
        GeneratorId = generatorId;
        DateTimeOffset = dateTimeOffset;
    }
}
