using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RandomGenerator;

public class RandomPasswordGenerator : StringGenerator
{
    protected const int DefaultPasswordLength = 10;
    protected const int DefaultPasswordMaxLength = 256;
    public RandomPasswordGenerator()
    {
        this.DefaultIncludeLowercase = true;
        this.DefaultIncludeUppercase = true;
        this.DefaultIncludeNumeric = true;
        this.DefaultIncludeSpecial = true;
    }

    public RandomPasswordGenerator IncludeLowercase(bool include)
    {
        DefaultIncludeLowercase = include;
        return this;
    }

    public RandomPasswordGenerator IncludeUppercase(bool include)
    {
        DefaultIncludeUppercase = include;
        return this;
    }

    public RandomPasswordGenerator IncludeNumeric(bool include)
    {
        DefaultIncludeNumeric = include;
        return this;
    }

    public RandomPasswordGenerator IncludeSpecial(bool include)
    {
        DefaultIncludeSpecial = include;
        return this;
    }

    public string Generate(int length)
    {
        if (length <= 0) length = DefaultPasswordLength;
        if (length > DefaultPasswordMaxLength) length = DefaultPasswordMaxLength;
        var charactersSet = BuildCharacterSet(DefaultIncludeLowercase, DefaultIncludeUppercase, DefaultIncludeNumeric, DefaultIncludeSpecial);
        return Generate(charactersSet, length);

    }


}
