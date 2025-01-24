using System.Text;

namespace RandomGenerator;
public static class Base63UrlShortener
{
    private const string Base63Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-";
    private const int EncodedLength = 8;
    private static readonly object _lock = new();

    public static string GenerateShortUrl()
    {
        lock (_lock)
        {
            byte[] buffer = new byte[5]; // 40 bits for randomness

            ulong value;
            Random.Shared.NextBytes(buffer);

            // Append a 16-bit timestamp component
            ushort timestamp = (ushort)(DateTime.UtcNow.Ticks % ushort.MaxValue);
            byte[] timestampBytes = BitConverter.GetBytes(timestamp);

            byte[] combined = new byte[buffer.Length + timestampBytes.Length];
            Array.Copy(buffer, 0, combined, 0, buffer.Length);
            Array.Copy(timestampBytes, 0, combined, buffer.Length, timestampBytes.Length);

            value = 0;
            for (int i = 0; i < combined.Length; i++)
            {
                value = (value << 8) | combined[i];
            }

            StringBuilder sb = new();
            for (int i = 0; i < EncodedLength; i++)
            {
                sb.Append(Base63Alphabet[(int)(value % 63)]);
                value /= 63;
            }

            return sb.ToString();
        }
    }
}
