using System.Globalization;
using SOFTEST_INTRO_Calculator;

var calculator = new Calculator();

Console.WriteLine("Calculator operations:");
Console.WriteLine("a=add, s=subtract, m=multiply, d=divide, f=factorial");

Console.Write("Operation: ");
string op = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
// Pre-define
double a = 0, b = 0;
int n = 0, r = 0;

if (op == "f") // If Factorial
{
    Console.Write("Integer n: "); // Input 1 digit
    string input = (Console.ReadLine() ?? "").Trim();
    bool nOk = int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out n);

    if (!nOk)
    {
        Console.WriteLine("Enter a whole integer (no decimal point) for n.");
        return;
    }
}
else if (op == "c") // If Circle Area
{
    Console.Write("Double n: "); // Input 1 digit
    string input = (Console.ReadLine() ?? "").Trim();
    bool nOk = int.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out n);

    if (!nOk)
    {
        Console.WriteLine("Enter finite numbers; use . for decimals.");
        return;
    }
}
else if (op == "ua" || op == "ub") // If Unknown A/B
{
    Console.Write("First integer: "); // Fiirst and Second
    string first = (Console.ReadLine() ?? "").Trim();

    Console.Write("Second integer: ");
    string second = (Console.ReadLine() ?? "").Trim();

    bool firstOk = int.TryParse(first, NumberStyles.Integer, CultureInfo.InvariantCulture, out n);
    bool secondOk = int.TryParse(second, NumberStyles.Integer, CultureInfo.InvariantCulture, out r);

    if (!firstOk || !secondOk)
    {
        Console.WriteLine("Enter a whole integer (no decimal point) for a and b.");
        return;
    }
}
else // +-*/▲
{
    Console.Write("First number: "); // Fiirst and Second
    string first = Console.ReadLine() ?? "";

    Console.Write("Second number: ");
    string second = Console.ReadLine() ?? "";

    bool firstOk = double.TryParse(first, NumberStyles.Float, CultureInfo.InvariantCulture, out a);
    bool secondOk = double.TryParse(second, NumberStyles.Float, CultureInfo.InvariantCulture, out b);

    if (!firstOk || !secondOk || !double.IsFinite(a) || !double.IsFinite(b))
    {
        Console.WriteLine("Enter finite numbers; use . for decimals.");
        return;
    }
}

try {
    double result = calculator.DoOperation(a, b, n, r, op); //HELP
    string text = result.ToString(CultureInfo.InvariantCulture);
    Console.WriteLine("Result: " + text);
}
catch (ArgumentException error) { Console.WriteLine(error.Message); }