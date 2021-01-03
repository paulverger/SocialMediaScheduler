using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialMediaScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;

namespace SocialMediaScheduler.Controllers
{
	public class SchedulerController : Controller
	{
		private string _TwitterApiKey;
		private string _TwitterApiSecret;
		private string _TwitterAccessToken;
		private string _TwitterAccessTokenSecret;

		
		public SchedulerController(IConfiguration config)
		{
			_TwitterApiKey = config["Twitter:ApiKey"];
			_TwitterApiSecret = config["Twitter:ApiKeySecret"];
			_TwitterAccessToken = config["Twitter:AccessToken"];
			_TwitterAccessTokenSecret = config["Twitter:AccessTokenSecret"];
			
		}


		[HttpGet]
		public IActionResult Index()
		{
			return View(new Tweet());
		}
		[HttpPost]
		public async Task<IActionResult> Index(Tweet tweet)
		{
			var userClient = new TwitterClient(_TwitterApiKey, _TwitterApiSecret, _TwitterAccessToken, _TwitterAccessTokenSecret);
			var user = await userClient.Users.GetAuthenticatedUserAsync();
			var userTweet = await userClient.Tweets.PublishTweetAsync(tweet.TweetText.ToString());
			return View();
		}
	}
}
