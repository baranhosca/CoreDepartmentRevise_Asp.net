using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.Models;
using System.Security.Claims;

namespace ProjectCore.Controllers
{
	public class LoginController : Controller
	{
		Context c = new Context();
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		public async Task<IActionResult> Login(Admin p)
		{
			var infos=c.Admins.FirstOrDefault(x=>x.User==p.User && x.Password==p.Password);
			if (infos != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, p.User)
				};
				var useridentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Staff");
			}
			return View();
		}
	}
}
