// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#primary-constructors

// ReSharper disable MemberCanBePrivate.Global

namespace Core.Source.PrimaryConstructors;

public interface IEntityShape
{
    byte Calculate();
}

// The constructor declaration carried to the class definition line.
// It can still implement interface and support inheritance.
public class Entity(byte index, string name) : IEntityShape
{
    public readonly byte Index = index;
    public readonly string Name = name;

    // Interface implementation.
    public byte Calculate()
    {
        throw new NotImplementedException();
    }

    // Normal methods can still be declared inside class.
    public string GetEntityId()
    {
        return string.Concat(Name, Index.ToString());
    }
}

// Readonly structs are also available to usage with primary constructors.
public readonly struct EntityEntry(int volume, string id)
{
    public readonly int Volume = volume;
    public readonly string Id = id;
}

// It was first introduced for records, but it's not restricted to records right now.
public record EntityPair(string PairIdentity)
{
    public string PairIdentity = PairIdentity;
}