// See https://aka.ms/new-console-template for more information
 // See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Leonardo;

var stopwatch = new Stopwatch();
stopwatch.Start();
var results = new List<FibonacciResult>();
foreach (var input in args)
{
    var int32 = Convert.ToInt32(input);
    var result = Fibonacci.Run(int32);
    results.Add(new FibonacciResult(int32, result));
}

stopwatch.Stop();
Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
foreach (var result in results)
{
    Console.WriteLine($"Fibonacci of {result.Input} is {result.Result}");
}

namespace Leonardo
{
    record FibonacciResult(int Input, int Result);
    public static class Fibonacci
    {
        public static int Run(int i)
        {
            if (i <= 2)
                return 1;
            return Run(i - 1) + Run(i - 2);
        } 
    }
}

