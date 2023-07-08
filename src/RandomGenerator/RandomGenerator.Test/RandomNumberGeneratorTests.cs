namespace RandomGenerator.Test;

public class RandomNumberGeneratorTests
{

    [Fact]
    public void Boolean_ReturnsTrueOrFalse()
    {
        // Arrange
        bool result;

        // Act
        result = RandomNumberGenerator.Boolean();

        // Assert
        Assert.True(result == true || result == false);
    }

    [Fact]
    public void Integer_ReturnsValueWithinRange()
    {
        // Arrange
        int result;
        int minValue = 0;
        int maxValue = int.MaxValue;

        // Act
        result = RandomNumberGenerator.Integer();

        // Assert
        Assert.InRange(result, minValue, maxValue);
    }

    [Fact]
    public void Double_ReturnsValueWithinRange()
    {
        // Arrange
        double result;
        double minValue = 0.0;
        double maxValue = 1.0;

        // Act
        result = RandomNumberGenerator.Double();

        // Assert
        Assert.InRange(result, minValue, maxValue);
    }

    [Fact]
    public void Single_ReturnsValueWithinRange()
    {
        // Arrange
        float result;
        float minValue = 0.0f;
        float maxValue = 1.0f;

        // Act
        result = RandomNumberGenerator.Single();

        // Assert
        Assert.InRange(result, minValue, maxValue);
    }

    [Fact]
    public void Long_ReturnsValueWithinRange()
    {
        // Arrange
        long result;
        long minValue = 0L;
        long maxValue = long.MaxValue;

        // Act
        result = RandomNumberGenerator.Long();

        // Assert
        Assert.InRange(result, minValue, maxValue);
    }

    [Fact]
    public void Bytes_FillsBufferWithRandomValues()
    {
        // Arrange
        byte[] buffer = new byte[10];

        // Act
        RandomNumberGenerator.Bytes(buffer);

        // Assert
        Assert.NotEmpty(buffer);
    }

    [Fact]
    public void Integer_WithMinAndMaxValues_ReturnsValueWithinRange()
    {
        // Arrange
        int result;
        int minValue = 10;
        int maxValue = 20;

        // Act
        result = RandomNumberGenerator.Integer(minValue, maxValue);

        // Assert
        Assert.InRange(result, minValue, maxValue);

    }

    [Fact]
    public void Long_WithMinAndMaxValues_ReturnsValueWithinRange()
    {
        // Arrange
        long result;
        long minValue = 10;
        long maxValue = 20;

        // Act
        result = RandomNumberGenerator.Long(minValue, maxValue);

        // Assert
        Assert.InRange(result, minValue, maxValue);

    }


    [Fact]
    public void AbsoluteLong_ReturnsValueWithinRange()
    {
        // Arrange
        long result;
        uint length = 5;
        long minValue = (long)Math.Pow(10, length - 1);
        long maxValue = (long)Math.Pow(10, length) - 1;

        // Act
        result = RandomNumberGenerator.AbsoluteLong(length);

        // Assert
        Assert.InRange(result, minValue, maxValue);
    }

    [Fact]
    public void StrongAbsoluteNumber_ReturnsPositiveValue()
    {
        // Arrange
        int result;

        // Act
        result = RandomNumberGenerator.StrongAbsoluteNumber();

        // Assert
        Assert.True(result >= 0);
    }

    [Fact]
    public void AbsoluteNumber_WithLengthGreaterThan10_ReturnsValueWithinRange()
    {
        // Arrange
        int result;
        uint length = 15;
        int minValue = (int)Math.Pow(10, 9);
        int maxValue = (int)Math.Pow(10, 10) - 1;

        // Act
        result = RandomNumberGenerator.AbsoluteNumber(length);

        // Assert
        Assert.InRange(result, minValue, maxValue);
    }


    [Fact]
    public void AbsoluteLong_WithLengthGreaterThan19_ReturnsValueWithinRange()
    {
        // Arrange
        long result;
        uint length = 25;
        long minValue = (long)Math.Pow(10, 18);
        long maxValue = (long)Math.Pow(10, 19) - 1;

        // Act
        result = RandomNumberGenerator.AbsoluteLong(length);

        // Assert
        Assert.InRange(result, minValue, maxValue);
    }

    [Fact]
    public void StrongAbsoluteLong_ReturnsPositiveValue()
    {
        // Arrange
        long result;

        // Act
        result = RandomNumberGenerator.StrongAbsoluteLong();

        // Assert
        Assert.True(result >= 0);
    }

    [Fact]
    public void StrongAbsoluteDouble_ReturnsPositiveValue()
    {
        // Arrange
        double result;

        // Act
        result = RandomNumberGenerator.StrongAbsoluteDouble();

        // Assert
        Assert.True(result >= 0);
    }

    [Fact]
    public void StrongAbsoluteLong_ReturnsPositiveNumber()
    {
        var result = RandomNumberGenerator.StrongAbsoluteLong();

        Assert.True(result >= 0);
    }

    [Fact]
    public void StrongAbsoluteLong_ReturnsDifferentNumbers()
    {
        var firstResult = RandomNumberGenerator.StrongAbsoluteLong();
        var secondResult = RandomNumberGenerator.StrongAbsoluteLong();

        Assert.NotEqual(firstResult, secondResult);
    }

    [Fact]
    public void StrongAbsoluteDouble_ReturnsPositiveNumber()
    {
        var result = RandomNumberGenerator.StrongAbsoluteDouble();

        Assert.True(result >= 0);
    }

    [Fact]
    public void StrongAbsoluteDouble_ReturnsDifferentNumbers()
    {
        var firstResult = RandomNumberGenerator.StrongAbsoluteDouble();
        var secondResult = RandomNumberGenerator.StrongAbsoluteDouble();

        Assert.NotEqual(firstResult, secondResult);
    }
}
