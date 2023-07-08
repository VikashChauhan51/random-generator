namespace RandomGenerator;

public class RandomNumberGenerator
{
    private static readonly Random random = new();

    public static bool Boolean() => random.Next(2) == 1;
    public static int Integer() => random.Next(0, int.MaxValue);
    public static double Double() => random.NextDouble();
    public static float Single() => random.NextSingle();
    public static long Long() => random.NextInt64();
    public static void Bytes(byte[] buffer) => random.NextBytes(buffer);
    public static int Integer(int minValue, int maxValue) => random.Next(minValue, maxValue);
    public static long Long(long minValue, long maxValue) => random.NextInt64(minValue, maxValue);
    public static int AbsoluteNumber(uint length = 10)
    {
        if (length > 10)
            length = 10;

        var maxValue = (int)Math.Pow(10, length) - 1;
        var minValue = (int)Math.Pow(10, length - 1);
        return Math.Abs(random.Next(minValue, maxValue));
    }

    public static long AbsoluteLong(uint length = 10)
    {
        if (length > 19)
            length = 19;

        var maxValue = (long)Math.Pow(10, length) - 1;
        var minValue = (long)Math.Pow(10, length - 1);
        return Math.Abs(random.NextInt64(minValue, maxValue));
    }

    public static int StrongAbsoluteNumber()
    {
        var buffer = new byte[4];
        Bytes(buffer);
        return Math.Abs(BitConverter.ToInt32(buffer, 0));
    }

    public static long StrongAbsoluteLong()
    {
        var buffer = new byte[8];
        Bytes(buffer);
        return Math.Abs(BitConverter.ToInt64(buffer, 0));
    }

    public static double StrongAbsoluteDouble()
    {
        var buffer = new byte[8];
        Bytes(buffer);
        return Math.Abs(BitConverter.ToDouble(buffer, 0));
    }

}
