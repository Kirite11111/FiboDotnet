﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Leonardo;

var stopwatch = new Stopwatch();
stopwatch.Start();
await using FibonacciDataContext context = new();
var results = await new Fibonacci(context).RunAsync(args);
stopwatch.Stop();
Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");
foreach (var result in results)
{
    Console.WriteLine($"Fibonacci of {result.Result} is {result.Result}");
}



