using Microsoft.AspNetCore.Mvc;
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
		private const string TwitterApiKey = "oL3nZP2goQaTQzKn10T01TrIE";
		private const string TwitterApiSecret = "azrebsfFEec2nnVVwESSGkJbMAl51NuJvRobtvY3Qk3TZ9En0O";
		private const string AccessToken = "1343720920498597890-ROtI9CYGcHgOnziHrkVA4rs0OdBAiT";
		private const string AccessTokenSecret = "SjF1vYkZ3h7GY2nNDmI2pM5myUJKl5QzquFkzWTYCY9tr";

		[HttpGet]
		public IActionResult Index()
		{
			return View(new Tweet());
		}
		[HttpPost]
		public async Task<IActionResult> Index(Tweet tweet)
		{
			var userClient = new TwitterClient(TwitterApiKey, TwitterApiSecret, AccessToken, AccessTokenSecret);
			var user = await userClient.Users.GetAuthenticatedUserAsync();
			var userTweet = await userClient.Tweets.PublishTweetAsync(tweet.TweetText.ToString());
			return View();
		}
	}
}
