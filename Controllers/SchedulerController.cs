using Microsoft.AspNetCore.Mvc;
using SocialMediaScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaScheduler.Controllers
{
	public class SchedulerController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View(new Tweet());
		}
		[HttpPost]
		public IActionResult Index(Tweet tweet)
		{
			return View();
		}
	}
}
