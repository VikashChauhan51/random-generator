using System.Runtime.CompilerServices;

namespace RandomGenerator;
public class IdGenerator : IIdGenerator
{
    private readonly long _generatorid;
    private int _sequence = 0;
    private long _lastgen = -1;

    private readonly long MASK_SEQUENCE;
    private readonly long MASK_TIME;
    private readonly long MASK_GENERATOR;

    private readonly int SHIFT_TIME;
    private readonly int SHIFT_GENERATOR;

    private readonly object _genlock = new();

    public IdGeneratorOptions Options { get; }
 
    public int Id => (int)_generatorid;

    public IdGenerator(int generatorId)
        : this(generatorId, new IdGeneratorOptions()) { }

    public IdGenerator(int generatorId, IdGeneratorOptions options)
    {
        _generatorid = generatorId;
        Options = options ?? throw new ArgumentNullException(nameof(options));

        var maxgeneratorid = (1U << Options.IdStructure.GeneratorIdBits) - 1;

        if (_generatorid < 0 || _generatorid > maxgeneratorid)
        {
            throw new ArgumentOutOfRangeException(nameof(generatorId), $"Generator ID must be between 0 and {maxgeneratorid}");
        }

        MASK_TIME = GetMask(options.IdStructure.TimestampBits);
        MASK_GENERATOR = GetMask(options.IdStructure.GeneratorIdBits);
        MASK_SEQUENCE = GetMask(options.IdStructure.SequenceBits);
        SHIFT_TIME = options.IdStructure.GeneratorIdBits + options.IdStructure.SequenceBits;
        SHIFT_GENERATOR = options.IdStructure.SequenceBits;
    }

    public long CreateId()
    {
        var id = CreateIdImpl(out var ex);
        return ex != null ? throw ex : id;
    }

    public bool TryCreateId(out long id)
    {
        id = CreateIdImpl(out var ex);
        return ex == null;
    }

    private long CreateIdImpl(out Exception? exception)
    {
        lock (_genlock)
        {
            var ticks = GetTicks();
            var timestamp = ticks & MASK_TIME;

            if (timestamp < _lastgen || ticks < 0)
            {
                exception = new InvalidSystemClockException($"Clock moved backwards. Refusing to generate id. Last timestamp: {_lastgen}, current timestamp: {timestamp}");
                return -1;
            }

            if (timestamp == _lastgen)
            {
                if (_sequence >= MASK_SEQUENCE)
                {
                    switch (Options.SequenceOverflowStrategy)
                    {
                        case SequenceOverflowStrategy.SpinWait:
                            SpinWait.SpinUntil(() => _lastgen != GetTicks());
                            return CreateIdImpl(out exception); // Try again
                        case SequenceOverflowStrategy.Throw:
                        default:
                            exception = new SequenceOverflowException("Sequence overflow.");
                            return -1;
                    }
                }
                _sequence++;
            }
            else 
            {
                _sequence = 0;
                _lastgen = timestamp;
            }
            exception = null;
            return (timestamp << SHIFT_TIME)
                | (_generatorid << SHIFT_GENERATOR)
                | (long)_sequence;
        }
    }

    public Id FromId(long id) =>
        new(
            (int)(id & MASK_SEQUENCE),
            (int)((id >> SHIFT_GENERATOR) & MASK_GENERATOR),
            Options.TimeSource.Epoch.Add(TimeSpan.FromTicks(((id >> SHIFT_TIME) & MASK_TIME) * Options.TimeSource.TickDuration.Ticks))
        );


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private long GetTicks() => Options.TimeSource.GetTicks();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static long GetMask(byte bits) => (1L << bits) - 1;
    private IEnumerable<long> IdStream()
    {
        while (true)
        {
            yield return CreateId();
        }
    }

    public IEnumerator<long> GetEnumerator() => IdStream().GetEnumerator();

}

