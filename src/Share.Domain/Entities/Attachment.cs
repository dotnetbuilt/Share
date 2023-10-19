using Share.Domain.Commons;

namespace Share.Domain.Entities;

public class Attachment:BaseEntity
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
}