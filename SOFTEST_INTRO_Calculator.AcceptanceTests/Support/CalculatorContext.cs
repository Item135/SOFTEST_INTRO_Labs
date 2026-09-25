using SOFTEST_INTRO_Calculator;
namespace SOFTEST_INTRO_Calculator.AcceptanceTests.Support;
public sealed class CalculatorContext
{
    public Calculator Calculator { get; set; } = null!;
    public double? Result { get; set; }
    public long? IntegerResult { get; set; }
    public Exception? Error { get; set; }
}

public class ReliabilityContext
{
    public double Mtbf { get; set; }
    public double Mttr { get; set; }
}

public class BasicReliabilityContext
{
    public double Lambda0 { get; set; }
    public double Nu0 { get; set; }
    public double Tau { get; set; }
}