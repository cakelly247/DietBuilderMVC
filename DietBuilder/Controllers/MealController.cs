using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class MealController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
