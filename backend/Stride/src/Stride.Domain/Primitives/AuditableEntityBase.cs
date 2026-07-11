namespace Stride.Domain.Primitives;

public abstract class AuditableEntityBase : EntityBase
{
    public DateTime CreatedAtUtc { get; set; }

    public DateTime? UpdatedAtUtc { get; set; }
}
