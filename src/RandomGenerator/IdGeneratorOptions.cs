namespace RandomGenerator;
public sealed class IdGeneratorOptions
{
    public IdStructure IdStructure { get; init; } = new();
    public ITimeSource TimeSource { get; init; } = new DefaultTimeSource();
    public SequenceOverflowStrategy SequenceOverflowStrategy { get; init; } = SequenceOverflowStrategy.Throw;
}
public sealed class IdStructure
{
    public byte TimestampBits { get; init; } = 41;
    public byte GeneratorIdBits { get; init; } = 10;
    public byte SequenceBits { get; init; } = 12;
}

public interface ITimeSource
{
    DateTime Epoch { get; }
    TimeSpan TickDuration { get; }
    long GetTicks();
}

public sealed class DefaultTimeSource : ITimeSource
{
    public DateTime Epoch { get; } = DateTime.UnixEpoch;
    public TimeSpan TickDuration { get; } = TimeSpan.FromMilliseconds(1);

    public long GetTicks() => (DateTime.UtcNow.Ticks - Epoch.Ticks) / TickDuration.Ticks;
}

public enum SequenceOverflowStrategy
{
    Throw,
    SpinWait
}


public class InvalidSystemClockException : Exception
{
    public InvalidSystemClockException(string message) : base(message) { }
}

public class SequenceOverflowException : Exception
{
    public SequenceOverflowException(string message) : base(message) { }
}
