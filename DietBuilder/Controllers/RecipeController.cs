using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class RecipeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
