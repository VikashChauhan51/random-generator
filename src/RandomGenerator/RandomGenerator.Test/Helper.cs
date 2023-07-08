
namespace RandomGenerator.Test;
public static class Helper
{
     static string SpecialCharacters = @"!#$%&*@\+_=|`~-^[]{}().,'%:";
    public static bool IsSpecialChar(this char c)
    {
        var specialCharacters = SpecialCharacters.ToArray();
        return specialCharacters.Contains(c);
    }
}
