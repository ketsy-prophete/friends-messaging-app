using myApi.Models;
using myApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace myApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TweetController : ControllerBase
    {
        private readonly ILogger<TweetController> _logger;
        private readonly ITweetRepository _tweetRepository;

        public TweetController(ILogger<TweetController> logger, ITweetRepository repository)
        {
            _logger = logger;
            _tweetRepository = repository;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Tweet> CreateTweet([FromBody] Tweet tweet)
        {
            if (!ModelState.IsValid || tweet == null)
            {
                return BadRequest();
            }
            var newTweet = _tweetRepository.CreateTweet(tweet);
            return CreatedAtAction(nameof(GetTweetById), new { tweetId = newTweet.TweetId }, newTweet);
        }

        [HttpGet]
        [Route("{tweetId:int}")]
        public ActionResult<Tweet> GetTweetById(int tweetId)
        {
            var tweet = _tweetRepository.GetTweetById(tweetId);
            if (tweet == null)
            {
                return NotFound();
            }
            return Ok(tweet);
        }

        [HttpGet]
        [Route("{userName}")] // something must be missing here
        public ActionResult<IEnumerable<Tweet>> GetTweetByUserName(string userName)
        {
            var tweets = _tweetRepository.GetTweetsByUserName(userName);
            if (tweets == null || !tweets.Any())
            {
                return NotFound();
            }
            return Ok(tweets);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tweet>> GetTweets()
        {
            return Ok(_tweetRepository.GetTweets());
        }

        [HttpPut]
        [Route("{tweetId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Tweet> UpdateTweet([FromBody] Tweet tweet, int tweetId)
        {
            if (!ModelState.IsValid || tweet == null || tweet.TweetId != tweetId)
            {
                return BadRequest();
            }
            var updatedTweet = _tweetRepository.UpdateTweet(tweet);
            if (updatedTweet == null)
            {
                return NotFound();
            }
            return Ok(updatedTweet);
        }

        [HttpDelete]
        [Route("{tweetId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteTweet(int tweetId)
        {
            var existingTweet = _tweetRepository.GetTweetById(tweetId);
            if (existingTweet == null)
            {
                return NotFound();
            }
            _tweetRepository.DeleteTweetById(tweetId);
            return NoContent();
        }
    }
}