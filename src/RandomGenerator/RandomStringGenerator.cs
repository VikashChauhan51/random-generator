using System.Text;

namespace RandomGenerator;

public class RandomStringGenerator : StringGenerator
{
    
    public string GenerateNumberString(int length) => Generate(BuildCharacterSet(false, false, true, false), length);
    public string GenerateAlphabeticString(int length) => Generate(BuildCharacterSet(true, true, false, false), length);
    public string GenerateSpecialCharsString(int length) => Generate(BuildCharacterSet(false, false, false, true), length);
    public string GenerateAlphaNumbersString(int length) => Generate(BuildCharacterSet(true, true, true, false), length);
    public string GenerateString(int length) => Generate(BuildCharacterSet(true, true, true, true), length);   
}
