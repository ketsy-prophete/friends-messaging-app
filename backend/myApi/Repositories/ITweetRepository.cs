using myApi.Models;

namespace myApi.Repositories;
public interface ITweetRepository
{
    Tweet CreateTweet(Tweet tweet);
    Tweet GetTweetById(int tweetId);
    IEnumerable<Tweet> GetTweets();
    IEnumerable<Tweet> GetTweetsByUserName(string userName); 
    Tweet UpdateTweet(Tweet tweet);
    void DeleteTweetById(int tweetId);
}