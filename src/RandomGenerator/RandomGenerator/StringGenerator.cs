using System.Text;
using System.Text.RegularExpressions;

namespace RandomGenerator;

public abstract class StringGenerator
{
    protected const string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
    protected const string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    protected const string NumericCharacters = "0123456789";
    protected const string SpecialCharacters = @"!#$%&*@\+_=|`~-^[]{}().,'%:";
    protected bool DefaultIncludeLowercase = false;
    protected bool DefaultIncludeUppercase = false;
    protected bool DefaultIncludeNumeric = false;
    protected bool DefaultIncludeSpecial = false;
    protected const int DefaultMaxAttempts = 10000;
    protected static readonly Random random = new();

    protected virtual ReadOnlySpan<char> BuildCharacterSet(bool includeLowercase, bool includeUppercase, bool includeNumeric,
            bool includeSpecial)
    {
        this.DefaultIncludeLowercase = includeLowercase;
        this.DefaultIncludeUppercase = includeUppercase;
        this.DefaultIncludeNumeric = includeNumeric;
        this.DefaultIncludeSpecial = includeSpecial;

        var characterSet = new StringBuilder();
        if (DefaultIncludeLowercase) characterSet.Append(LowercaseCharacters);

        if (DefaultIncludeUppercase) characterSet.Append(UppercaseCharacters);

        if (DefaultIncludeNumeric) characterSet.Append(NumericCharacters);

        if (DefaultIncludeSpecial) characterSet.Append(SpecialCharacters);
        return characterSet.ToString();

    }


    protected string Generate(ReadOnlySpan<char> text, int length)
    {
        string output = string.Empty;
        var attempts = 0;
        do
        {
            output = GenerateString(text, length);
            attempts++;
        } while (attempts < DefaultMaxAttempts && !IsValid(output, length));

        return output;

    }

    private string GenerateString(ReadOnlySpan<char> text, int length)
    {
        var stringBuilder = new StringBuilder(length);

        for (var i = 0; i < length; i++)
        {
            stringBuilder.Append(text[random.Next(text.Length)]);
        }

        return stringBuilder.ToString();
    }

    private bool IsValid(string text, int length)
    {
        const string regexLowercase = @"[a-z]";
        const string regexUppercase = @"[A-Z]";
        const string regexNumeric = @"[\d]";

        var lowerCaseIsValid = !DefaultIncludeLowercase ||
                               DefaultIncludeLowercase && Regex.IsMatch(text, regexLowercase);
        var upperCaseIsValid = !DefaultIncludeUppercase ||
                               DefaultIncludeUppercase && Regex.IsMatch(text, regexUppercase);
        var numericIsValid = !DefaultIncludeNumeric ||
                             DefaultIncludeNumeric && Regex.IsMatch(text, regexNumeric);

        var specialIsValid = !DefaultIncludeSpecial;

        if (DefaultIncludeSpecial)
        {
            var listA = SpecialCharacters.ToCharArray();
            var listB = text.ToCharArray();

            specialIsValid = listA.Any(x => listB.Contains(x));
        }

        return lowerCaseIsValid && upperCaseIsValid && numericIsValid && specialIsValid &&
               text.Length == length;
    }
}
