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
		private string _AccessToken;
		private string _AccessTokenSecret;

		private readonly IConfiguration _config;

		public SchedulerController(IConfiguration config)
		{
		    _config = config;
			_TwitterApiKey = _config["Twitter:ApiKey"];
			_TwitterApiSecret = _config["Twitter:ApiKeySecret"];
			_AccessToken = _config["Twitter:AccessToken"];
			_AccessTokenSecret = _config["Twitter:AccessTokenSecret"];
			
		}


		[HttpGet]
		public IActionResult Index()
		{
			return View(new Tweet());
		}
		[HttpPost]
		public async Task<IActionResult> Index(Tweet tweet)
		{
			var userClient = new TwitterClient(_TwitterApiKey, _TwitterApiSecret, _AccessToken, _AccessTokenSecret);
			var user = await userClient.Users.GetAuthenticatedUserAsync();
			var userTweet = await userClient.Tweets.PublishTweetAsync(tweet.TweetText.ToString());
			return View();
		}
	}
}
