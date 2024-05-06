// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#inline-arrays

using System.Runtime.CompilerServices;

namespace Core.Source.InlineArrays;

public readonly struct Entity(byte id)
{
    public readonly byte Id = id;
}

[InlineArray(10)]
public struct EntityBuffer(Entity attachedEntity)
{
    public Entity AttachedEntity = attachedEntity;
}