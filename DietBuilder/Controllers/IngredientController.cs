using DietBuilder.Data.Entities;
using DietBuilder.Models.Ingredient;
using DietBuilder.Services.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class IngredientController : Controller
	{
		private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
			_service = service;
        }
        public async Task<IActionResult> Index()
		{
			List<IngredientListItem> ingredients = await _service.GetAllIngredientsAsync();
			return View(ingredients);
		}
	}
}
