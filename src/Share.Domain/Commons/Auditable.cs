namespace Share.Domain.Commons;

public abstract class Auditable:BaseEntity
{
    public DateTimeOffset UpdatedAt { get; set; }
}