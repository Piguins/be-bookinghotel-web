using System.Reflection;

namespace Domain.Common.Primitives;

public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

    protected Enumeration(int value, string name)
    {
        Value = value;
        Name = name;
    }

    public int Value { get; protected init; }
    public string Name { get; protected init; } = string.Empty;

    public static TEnum? FromValue(int value) => Enumerations.TryGetValue(value, out var enumeration) ? enumeration : default;

    public static TEnum? FromName(string name) => Enumerations.Values.FirstOrDefault(e => e.Name == name);

    public bool Equals(Enumeration<TEnum>? other) =>
        other is not null && GetType() == other.GetType() && Value == other.Value;

    public override bool Equals(object? obj) =>
        obj is not null && obj is Enumeration<TEnum> other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();

    public override string? ToString() => Name;

    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);

        var fieldsForType = enumerationType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);
        return fieldsForType.ToDictionary(e => e.Value);
    }

    // #pragma warning disable CS8618
    //     protected Enumeration() { }
    // #pragma warning restore CS8618
}
