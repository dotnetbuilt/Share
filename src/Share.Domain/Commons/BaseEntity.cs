namespace Share.Domain.Commons;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
}