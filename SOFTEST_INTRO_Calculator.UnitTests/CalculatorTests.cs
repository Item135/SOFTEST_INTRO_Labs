using SOFTEST_INTRO_Calculator;
using NUnit.Framework;

namespace SOFTEST_INTRO_Calculator.UnitTests;

public class CalculatorTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }
    
    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange: the calculator is created in SetUp.
        // Act
        double result = _calculator.Add(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }

    // Addition
    [TestCase(0, 0, 0)]
    [TestCase(0, 5, 5)]
    [TestCase(-3, 8, 5)]
    [TestCase(0.1, 0.2, 0.3)]
    public void Add_RepresentativeInputs_ReturnsSum(
        double a, double b, double expected)
    {
        double result = _calculator.Add(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(1, 2, 0.5)]
    [TestCase(0, 15, 0)]
    [TestCase(15, -3, -5)]
    public void Divide_RepresentativeInputs_ReturnsDiv(
        double a, double b, double expected)
    {
        double result = _calculator.Divide(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    // Divide by zero
    [TestCase(15, 0)]
    [TestCase(0, 0)]
    public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
    {
        Assert.That(() => _calculator.Divide(a, b),
        Throws.TypeOf<ArgumentException>());
    }

    // Factorial boundary
    [TestCase(-1)]
    [TestCase(21)]
    public void Factorial_OutOfRange_ThrowsArgumentOutOfRangeException(int n)
    {
        Assert.That(() => _calculator.Factorial(n),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // Factorial Test Case
    [TestCase(0, 1L)]
    [TestCase(1, 1L)]
    [TestCase(5, 120L)]
    [TestCase(20, 2432902008176640000L)]
    public void Factorial_ValidInputs_ReturnsExpected(int n, long expected)
    {
        long result = _calculator.Factorial(n);
        Assert.That(result, Is.EqualTo(expected));
    }

    // Triangle Test Cases
    [TestCase(3, 4, 6)]
    [TestCase(5, 11, 27.5)]
    [TestCase(4, 0, 0)]
    public void Triangle_ValidInputs_ReturnsExpected(
        double a, double b, double expected)
    {
        double result = _calculator.TriangleArea(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-2, 0)]
    public void Triangle_OutOfRange_ThrowsArgumentOutOfRangeException(double a, double b)
    {
        Assert.That(() => _calculator.TriangleArea(a, b),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // Triangle Test Cases
    [TestCase(5, Math.PI*25)]
    [TestCase(1, Math.PI)]
    [TestCase(0, 0)]
    public void Circle_ValidInputs_ReturnsExpected(double n, double expected)
    {
        double result = _calculator.CircleArea(n);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-3)]
    public void Circle_OutOfRange_ThrowsArgumentOutOfRangeException(double n)
    {
        Assert.That(() => _calculator.CircleArea(n),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    // Unknown A/B (Permutation & Combination)
    [TestCase(5, 5, 120L, 1L)]
    [TestCase(5, 4, 120L, 5L)]
    [TestCase(5, 3, 60L, 10L)]
    [TestCase(5, 0, 1L, 1L)]
    [TestCase(0, 0, 1L, 1L)]
    [TestCase(5, 2, 20L, 10L)]
    public void UnknownFunctions_ValidInputs_ReturnExpected(int n, int r, long expectedA, long expectedB)
    {
        Assert.That(_calculator.UnknownFunctionA(n, r), Is.EqualTo(expectedA));
        Assert.That(_calculator.UnknownFunctionB(n, r), Is.EqualTo(expectedB));
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    public void UnknownFunctions_InvalidInputs_ThrowArgumentOutOfRangeException(int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionA(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => _calculator.UnknownFunctionB(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    
    // Availability
    [Test]
    public void FailureIntensity_TauZero_ReturnsLambda0()
    {
        Assert.That(_calculator.FailureIntensity(10, 1000, 0), Is.EqualTo(10).Within(1e-9));
    }

    [Test]
    public void FailureIntensity_NormalPositiveTau_ReturnsExpectedValue()
    {
        double expected = 10 * Math.Exp(-10.0 * 100 / 1000);
        Assert.That(_calculator.FailureIntensity(10, 1000, 100), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 1000, 10)]
    [TestCase(-5, 1000, 10)]
    [TestCase(10, 0, 10)]
    [TestCase(10, -5, 10)]
    [TestCase(10, 1000, -1)]
    public void FailureIntensity_InvalidParameters_ThrowsArgumentOutOfRangeException(double lambda0, double nu0, double tau)
    {
        Assert.That(() => _calculator.FailureIntensity(lambda0, nu0, tau),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void CumulativeFailures_TauZero_ReturnsZero()
    {
        Assert.That(_calculator.CumulativeFailures(10, 1000, 0), Is.EqualTo(0).Within(1e-9));
    }

    [Test]
    public void CumulativeFailures_NormalPositiveTau_ReturnsExpectedValue()
    {
        double expected = 1000 * (1 - Math.Exp(-10.0 * 100 / 1000));
        Assert.That(_calculator.CumulativeFailures(10, 1000, 100), Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 1000, 10)]
    [TestCase(-5, 1000, 10)]
    [TestCase(10, 0, 10)]
    [TestCase(10, -5, 10)]
    [TestCase(10, 1000, -1)]
    public void CumulativeFailures_InvalidParameters_ThrowsArgumentOutOfRangeException(double lambda0, double nu0, double tau)
    {
        Assert.That(() => _calculator.CumulativeFailures(lambda0, nu0, tau),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
}