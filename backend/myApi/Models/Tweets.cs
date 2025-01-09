using System.ComponentModel.DataAnnotations;

namespace myApi.Models;

public class Tweet
{
    public int TweetId { get; set; }

    [Required]
    public string? TweetMessage { get; set; }

    [Required]
    public string? UserName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}