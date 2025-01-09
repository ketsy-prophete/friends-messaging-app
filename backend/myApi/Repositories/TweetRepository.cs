using myApi.Migrations;
using myApi.Models;

namespace myApi.Repositories;

public class TweetRepository : ITweetRepository
{
    private readonly TweetDbContext _context;
    public TweetRepository(TweetDbContext context)
    {
        _context = context;
    }

    public Tweet CreateTweet(Tweet newTweet)
    {
        _context.Tweet.Add(newTweet);
        _context.SaveChanges();
        return newTweet;
    }

    public void DeleteTweetById(int tweetId)
    {
        var tweet = _context.Tweet.Find(tweetId);
        if (tweet != null)
        {
            _context.Tweet.Remove(tweet);
            _context.SaveChanges();
        }
    }

    public Tweet? GetTweetById(int tweetId)
    {
        return _context.Tweet.SingleOrDefault(c => c.TweetId == tweetId);
    }

    public IEnumerable<Tweet> GetTweets()
    {
        return _context.Tweet.ToList();
    }

    public IEnumerable<Tweet> GetTweetsByUserName(string userName)
    {
        return _context.Tweet.Where(t => t.UserName == userName).ToList();
    }

    public Tweet? UpdateTweet(Tweet newTweet)
    {
        var originalTweet = _context.Tweet.Find(newTweet.TweetId);
        if (originalTweet != null)
        {
            originalTweet.TweetMessage = newTweet.TweetMessage;
            originalTweet.UserName = newTweet.UserName;
            originalTweet.CreatedAt = newTweet.CreatedAt;
            _context.SaveChanges();
        }
        return originalTweet;
    }
}