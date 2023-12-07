using DietBuilder.Models.Recipe;
using DietBuilder.Models.RecipeIngredient;
using DietBuilder.Services.Ingredient;
using DietBuilder.Services.Recipe;
using DietBuilder.Services.RecipeIngredient;
using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class RecipeIngredientController : Controller
	{
		private readonly IRecipeIngredientService _service;

		private readonly IIngredientService _ingredientService;

		private readonly IRecipeService _recipeService;

		public RecipeIngredientController(IRecipeIngredientService service,
										  IIngredientService ingredientService,
										  IRecipeService recipeService)
		{
			_service = service;
			_ingredientService = ingredientService;
			_recipeService = recipeService;
		}

		// public async Task<IActionResult> Index(int recipeId)
		// {
		// 	if (!ModelState.IsValid)
		// 		return View();
		//
		// 	var recipe = await _recipeService.GetRecipeById(recipeId);
		//
		// 	//if (recipe is null)
		// 	//	return RedirectToAction(nameof(Index));
		//
		// 	var recipeIngredients = recipe!.RecipeIngredients;
		//
		// 	return View(recipeIngredients);
		// }
		//
		// [ActionName("Details")]
		// public async Task<IActionResult> RecipeIngredient(int id)
		// {
		// 	if (!ModelState.IsValid)
		// 		return View();
		//
		// 	var recipeIngredient = await _service.GetRecipeIngredientById(id);
		//
		// 	if (recipeIngredient is null)
		// 		return RedirectToAction(nameof(Index));
		//
		// 	return View(recipeIngredient);
		// }

		[HttpGet("Recipe/{recipeId}/Ingredients/Create")]
		public async Task<IActionResult> Create(int? recipeId)
		{
			if (recipeId is null || recipeId == 0)
				return View(new RecipeIngredientCreate());

			var ingredients = (await _ingredientService.GetAllIngredientsAsync())
				.Select(i => new IngredientChecked()
				{
					Name = i.Name,
					Id = i.Id,
					IsSelected = false
				})
				.ToList();
			var model = new RecipeIngredientCreate()
			{
				Ingredients = ingredients,
				Recipe = await _recipeService.GetRecipeById(recipeId ?? 0)
			};

			return View(model);
		}

		[HttpPost("Recipe/{recipeId}/Ingredients/Create")]
		public async Task<IActionResult> Create(RecipeIngredientCreate model, int? recipeId)
		{
			if (!ModelState.IsValid)
				return View(model);

			model.RecipeId = recipeId ?? 0;
			await _service.CreateRecipeIngredientsAsync(model);

			return RedirectToAction("Details", "Recipe", new { id = model.RecipeId });
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var recipeIngredient = await _service.GetRecipeIngredientById(id);

			if (recipeIngredient is null)
				return View();

			var recipeIngredientEdit = new RecipeIngredientUpdate()
			{
				Id = recipeIngredient.Id,
				QuantityOf = recipeIngredient.QuantityOf
			};

			return View(recipeIngredientEdit);
		}

		[HttpPost("Recipe/{recipeId}/Ingredient/{id}/delete")]
		public async Task<IActionResult> Delete(int? recipeId, int id)
		{
			if (!ModelState.IsValid)
				return View();

			await _service.DeleteRecipeIngredientAsync(id);

			return RedirectToAction("Details", "Recipe", new { id = recipeId });
		}
	}
}