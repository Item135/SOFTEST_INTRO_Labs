using NUnit.Framework;
using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorFactorialSteps
{
    private readonly CalculatorContext _context;
    public UsingCalculatorFactorialSteps(CalculatorContext context)
        => _context = context;

    [When("I have entered 0 into the calculator and press factorial")]
    public void WhenIHaveEntered1AndPressFactorial()
    {
        _context.Result = _context.Calculator.Factorial(0);
    }

    [When("I have entered <number> into the calculator and press factorial")]
    public void WhenIHaveEnteredAndPressFactorial(int number)
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result = _context.Calculator.Factorial(number);
        }
        catch (ArgumentException error)
        {
            _context.Error = error;
        }
    }
}