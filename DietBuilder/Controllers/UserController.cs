using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
