// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#default-lambda-parameters

// We can now define default value for the lambda parameter.
// ReSharper disable once ConvertToLocalFunction

var lambda = (byte count = 5) => $"The passed count is {count}";

lambda();

// ReSharper disable once EmptyNamespace
namespace Core.Source.DefaultLambdaParameters
{
}