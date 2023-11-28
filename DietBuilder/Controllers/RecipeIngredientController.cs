using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class RecipeIngredientController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
