namespace Stride.Domain.Primitives;

public abstract class EntityBase
{
    public Guid Id { get; set; }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is null || obj.GetType() != GetType()) return false;

        return Id == ((EntityBase)obj).Id;
    }
}
