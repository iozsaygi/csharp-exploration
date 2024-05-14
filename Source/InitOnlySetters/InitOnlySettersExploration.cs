// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/init

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Core.Source.InitOnlySetters;

// Basic user class with name and surname.
public class User
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Name { get; set; }
    public string Surname { get; set; }
}

// Now class that implements 'init' only setters.
public class ProtectedUser
{
    public string Name { get; init; }
    public string Surname { get; init; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}

public class InitOnlySettersExplorationPlayground
{
    public static void Playground()
    {
        // Create a new instance of user and we can set its properties.
        // ReSharper disable once UseObjectOrCollectionInitializer
        var user = new User();
        user.Name = "User";
        user.Surname = "Surname";

        // Now try to create a protected user and set its properties from here.
        // It will throw compilation errors since they are declared with 'init' setters.
        // ReSharper disable once UnusedVariable
        var protectedUser = new ProtectedUser();
        // protectedUser.Name = "Protected User";
        // protectedUser.Surname = "Protected Surname";
    }
}