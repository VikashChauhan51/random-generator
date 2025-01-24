using System.Text;

namespace RandomGenerator;
public static class IdGeneratorBase32
{
    private const string Base32Alphabet = "0123456789abcdefghjkmnpqrstvwxyz";
    private const int EncodedLength = 26;
    private static readonly char[] defaultData = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    private static readonly object _lock = new();
    public static string GenerateId()
    {
        lock (_lock)
        {
            Guid guid = Guid.NewGuid();
            byte[] bytes = guid.ToByteArray();
            ulong timestamp = (ulong)(DateTime.UtcNow - DateTime.UnixEpoch).TotalMilliseconds;

            byte[] combined = new byte[16];
            Array.Copy(BitConverter.GetBytes(timestamp), 2, combined, 0, 6);
            Array.Copy(bytes, 0, combined, 6, 10);

            StringBuilder sb = new();

            for (int i = 0; i < combined.Length; i += 5)
            {
                int remainingBytes = Math.Min(5, combined.Length - i);
                ulong value = 0;
                for (int j = 0; j < remainingBytes; j++)
                {
                    value = (value << 8) | combined[i + j];
                }

                int bitsToEncode = remainingBytes * 8;
                int charsToEncode = (int)Math.Ceiling(bitsToEncode / 5.0);

                for (int j = charsToEncode - 1; j >= 0; j--)
                {
                    sb.Append(Base32Alphabet[(int)((value >> (j * 5)) & 0x1F)]);
                }
            }

            while (sb.Length < EncodedLength)
            {
                sb.Append(defaultData[Random.Shared.Next(0, defaultData.Length)]);
            }

            return sb.ToString();
        }
    }
}
