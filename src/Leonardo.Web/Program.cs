using System.Text.Json.Serialization;
using Leonardo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddDbContext<FibonacciDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<Fibonacci>();

FibonacciDataContext context = new();

app.MapGet("/", () => "Hello World 2!");

app.MapGet("/fibonacci", async (Fibonacci fibonacci, ILogger<Program> logger) =>
{
    logger.LogInformation("Application name: {ApplicationName}", "Leonardo");
    var result = await fibonacci.RunAsync(["42"]);
    return Results.Json(result, FibonacciContext.Default.ListFibonacciResult);
});

app.Run();

[JsonSerializable(typeof(List<FibonacciResult>))]
internal partial class FibonacciContext : JsonSerializerContext
{
}
