using Reqnroll;
using NUnit.Framework;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _calculatorContext;
    private readonly BasicReliabilityContext _reliability;
    private Exception? _caughtException;

    public UsingCalculatorBasicReliabilitySteps(CalculatorContext calculatorContext, BasicReliabilityContext reliability)
    {
        _calculatorContext = calculatorContext;
        _reliability = reliability;
    }

    [Given("the Basic Musa parameters are")]
    public void GivenTheBasicMusaParametersAre(Table table)
    {
        var row = table.Rows[0];
        _reliability.Lambda0 = double.Parse(row["lambda0"]);
        _reliability.Nu0 = double.Parse(row["nu0"]);
        _reliability.Tau = double.Parse(row["tau"]);
    }

    [When("I calculate the current failure intensity")]
    public void WhenICalculateTheCurrentFailureIntensity()
    {
        _calculatorContext.Result = _calculatorContext.Calculator.FailureIntensity(
            _reliability.Lambda0, _reliability.Nu0, _reliability.Tau);
    }

    [When("I calculate the expected cumulative number of failures")]
    public void WhenICalculateTheExpectedCumulativeNumberOfFailures()
    {
        _calculatorContext.Result = _calculatorContext.Calculator.CumulativeFailures(
            _reliability.Lambda0, _reliability.Nu0, _reliability.Tau);
    }

    [When("I try to calculate the current failure intensity")]
    public void WhenITryToCalculateTheCurrentFailureIntensity()
    {
        try
        {
            _calculatorContext.Calculator.FailureIntensity(_reliability.Lambda0, _reliability.Nu0, _reliability.Tau);
            _caughtException = null;
        }
        catch (Exception ex)
        {
            _caughtException = ex;
        }
    }

    [Then("the result should be approximately {double}")]
    public void ThenTheResultShouldBeApproximately(double expected)
    {
        Assert.That(_calculatorContext.Result, Is.EqualTo(expected).Within(1e-6));
    }

    [Then("the calculator should reject the input")]
    public void ThenTheCalculatorShouldRejectTheInput()
    {
        Assert.That(_caughtException, Is.Not.Null.And.TypeOf<ArgumentOutOfRangeException>());
    }
}