using System.ComponentModel.DataAnnotations;
using Share.Domain.Commons;

namespace Share.Domain.Entities;

public class Story:Auditable
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Text { get; set; }
    public int Likes { get; set; }
    public int Comments { get; set; }
    public int Saved { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}