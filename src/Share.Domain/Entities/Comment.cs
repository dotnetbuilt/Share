using System.Text.Json.Serialization;
using Share.Domain.Commons;

namespace Share.Domain.Entities;

public class Comment:Auditable
{
    public string Text { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long StoryId { get; set; }
    public Story Story { get; set; }

    [JsonIgnore]
    public ICollection<Reply> Replies { get; set; }
}