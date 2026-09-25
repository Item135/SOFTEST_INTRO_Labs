using Reqnroll;
using NUnit.Framework;
using SOFTEST_INTRO_Calculator;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorAvailabilitySteps
{
    private readonly CalculatorContext _calculatorContext;
    private readonly ReliabilityContext _reliability;

    public UsingCalculatorAvailabilitySteps(CalculatorContext calculatorContext, ReliabilityContext reliability)
    {
        _calculatorContext = calculatorContext;
        _reliability = reliability;
    }

    [Given("the reliability values are")]
    public void GivenTheReliabilityValuesAre(Table table)
    {
        var values = table.Rows[0];
        _reliability.Mtbf = double.Parse(values["MTBF"]);
        _reliability.Mttr = double.Parse(values["MTTR"]);
    }

    [When("I have entered {double} and {int} into the calculator and press MTBF")]
    public void WhenIHaveEnteredAndPressMtbf(double operatingTime, int failureCount)
    {
        _calculatorContext.Result = _calculatorContext.Calculator.Mtbf(operatingTime, failureCount);
    }

    [When("I have entered {double} and {double} into the calculator and press Availability")]
    public void WhenIHaveEnteredAndPressAvailability(double mtbf, double mttr)
    {
        _calculatorContext.Result = _calculatorContext.Calculator.Availability(mtbf, mttr);
    }

    [When("I calculate Availability from these values")]
    public void WhenICalculateAvailabilityFromTheseValues()
    {
        _calculatorContext.Result = _calculatorContext.Calculator.Availability(_reliability.Mtbf, _reliability.Mttr);
    }
}