namespace SOFTEST_INTRO_Calculator;
using System.Globalization;
using System.Linq;
public class Calculator
{
    public double Add(double a, double b)
    {
        if (IsBinaryLooking(a) && IsBinaryLooking(b))
        {
            string concatenated =
                ((long)a).ToString(CultureInfo.InvariantCulture) +
                ((long)b).ToString(CultureInfo.InvariantCulture);
            return Convert.ToInt64(concatenated, 2);
        }
        return a + b;
    }

    private static bool IsBinaryLooking(double x) =>
        x >= 0
        && x == Math.Floor(x)
        && ((long)x).ToString(CultureInfo.InvariantCulture).All(c => c == '0' || c == '1');

    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    // Starter version: complete the zero-divisor rule in section 5.
    public double Divide(double a, double b)
    {
        if (b == 0)
            throw new ArgumentException("Cannot divide by zero.", nameof(b));
        return a / b;
    }
    public long Factorial(int n)
    {
        if (n < 0 || n > 20) // Check Range
            throw new ArgumentOutOfRangeException("n must be between 0 and 20.", nameof(n));

        long result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }
    public double TriangleArea(double a, double b)
    {
        if (a < 0 || b < 0) // Check Range
            throw new ArgumentOutOfRangeException("Enter positive numbers only");
        return a * b * 0.5;
    }
    public double CircleArea(double n)
    {
        if (n < 0) // Check Range
            throw new ArgumentOutOfRangeException("Enter positive numbers only");
        return Math.PI * n * n;
    }
    public long UnknownFunctionA(int n, int r) // Permutation
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
            throw new ArgumentOutOfRangeException(nameof(r), "Require 0 <= r <= n <= 20.");
        return Factorial(n) / Factorial(n - r);
    }
    public long UnknownFunctionB(int n, int r) // Combination
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
            throw new ArgumentOutOfRangeException(nameof(r), "Require 0 <= r <= n <= 20.");
        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }
    public double DoOperation(double a, double b, int n, int r, string op)
    {
        return op switch
        {
            "a" => Add(a, b),
            "s" => Subtract(a, b),
            "m" => Multiply(a, b),
            "d" => Divide(a, b),
            "f" => Factorial(n),
            "t" => TriangleArea(a, b),
            "c" => CircleArea(n),
            "ua" => UnknownFunctionA(n, r),
            "ub" => UnknownFunctionB(n, r),
            _ => throw new ArgumentException("Unknown operation.")
        };
    }

    // Mean time between failures (MBTF). operatingTime and failureCount must both be positive.
    public double Mtbf(double operatingTime, int failureCount)
    {
        if (operatingTime <= 0)
            throw new ArgumentOutOfRangeException(nameof(operatingTime), "Operating time must be positive.");
        if (failureCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(failureCount), "Number of failures must be positive.");
        return operatingTime / failureCount;
    }

    // Availability = MTBF / (MTBF + MTTR)
    public double Availability(double mtbf, double mttr)
    {
        if (mtbf < 0)
            throw new ArgumentOutOfRangeException(nameof(mtbf), "MTBF cannot be negative.");
        if (mttr < 0)
            throw new ArgumentOutOfRangeException(nameof(mttr), "MTTR cannot be negative.");
        double denominator = mtbf + mttr;
        if (denominator <= 0)
            throw new ArgumentOutOfRangeException(nameof(mttr), "MTBF + MTTR must be positive.");
        return mtbf / denominator;
    }

    // Current failure intensity λ(τ). τ is accumulated execution time, same unit as ν₀/λ₀ imply (e.g. CPU-hours).
    public double FailureIntensity(double lambda0, double nu0, double tau)
    {
        if (lambda0 <= 0) throw new ArgumentOutOfRangeException(nameof(lambda0), "lambda0 must be positive.");
        if (nu0 <= 0) throw new ArgumentOutOfRangeException(nameof(nu0), "nu0 must be positive.");
        if (tau < 0) throw new ArgumentOutOfRangeException(nameof(tau), "tau cannot be negative.");
        return lambda0 * Math.Exp(-lambda0 * tau / nu0);
    }

    // Expected cumulative failures μ(τ), same execution-time unit as FailureIntensity.
    public double CumulativeFailures(double lambda0, double nu0, double tau)
    {
        if (lambda0 <= 0) throw new ArgumentOutOfRangeException(nameof(lambda0), "lambda0 must be positive.");
        if (nu0 <= 0) throw new ArgumentOutOfRangeException(nameof(nu0), "nu0 must be positive.");
        if (tau < 0) throw new ArgumentOutOfRangeException(nameof(tau), "tau cannot be negative.");
        return nu0 * (1 - Math.Exp(-lambda0 * tau / nu0));
    }
}