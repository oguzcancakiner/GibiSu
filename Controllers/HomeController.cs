﻿using GibiSu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GibiSu.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager)
		{

			if(roleManager.FindByNameAsync("Administrator").Result == null) 
			{
                IdentityRole identityRole = new IdentityRole("Administrator");
                roleManager.CreateAsync(identityRole).Wait();
            }

			_logger = logger;
		}




		public IActionResult Index()
		{

            return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[Authorize(Roles ="Administrator")]
        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}