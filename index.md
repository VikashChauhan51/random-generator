# RandomGenerator
A library which generates random passwords, numbers, sentences, paragraphs and texts.

![RandomGenerator Logo](https://github.com/VikashChauhan51/random-generator/blob/main/icon.png "RandomGenerator Logo")
## NuGet

Install via NuGet: ``` Install-Package RandomGenerator ```

[![Nuget Downloads](https://img.shields.io/nuget/dt/RandomGenerator.svg)](https://www.nuget.org/packages/RandomGenerator)

[Or click here to go to the package landing page](https://www.nuget.org/packages/RandomGenerator)

It is Compatible with .NET **Core 6.0+**.

## Basic usage

```C#
// generate random sentence.
 var generator = new RandomSentenceGenerator();
 // maximum number of words in the sentence. Here, the number of words depends on the configured part of speech. if nothing is configured then its return empty string. Defualt all part of speech are configured.
 var result = generator.Generate(10);

```
```C#
//generate random paragraph.
var generator = new RandomParagraphGenerator();
// this paragraph contains 3 sentences with words between 5 to 10. The number of words depends on the configured part of speech. if nothing is configured then its return empty string. Defualt all part of speech are configured.
var result = generator.Generate(3, 5, 10);

```
```C#
//generate random text.
var generator = new RandomTextGenerator();
//this text contains 3 paragraphs with sentences between 3 to 5 to each paragraph and each sentence contains words between 10 to 15. Here, the number of words depends on the configured part of speech. if nothing is configured then its return empty string. Defualt all part of speech are configured.
var result = generator.Generate(3, 3, 5, 10, 15);

```

```C#
// generate random number string (0-9) of specific length.
new RandomStringGenerator().GenerateNumberString(15)

```

```C#
// generate random alphabetic string (a-z,A-Z) of specific length.
new RandomStringGenerator().GenerateAlphabeticString(15)
```

```C#
// generate random alphnumeric string (a-z,A-Z,0-9) of specific length.
new RandomStringGenerator().GenerateAlphaNumbersString(15)
```

```C#
// generate random alphnumeric string (a-z,A-Z,0-9) with special characters of specific length.
new RandomStringGenerator().GenerateString(15)
```

```C#
// generate random password of specific length. this will generate password string up to 256 characters.
new RandomPasswordGenerator().Generate(10);
```

```C#
// generate random number of specific length.
// this function can generate a random number of length between 1 to 10.
RandomNumberGenerator.AbsoluteNumber(10);
```
```C#
// generate random number of specific length.
// this function can generate a random number of length between 1 to 19.
RandomNumberGenerator.AbsoluteLong(10);
```

```C#
// generate random unique number.
RandomNumberGenerator.Number();
```

```C#
// generate random password of specific length with configuration.
var password = new RandomPasswordGenerator()
            .IncludeNumeric(true)
            .IncludeLowercase(true)
            .IncludeUppercase(true)
            .IncludeSpecial(true)
            .Generate(10);

```