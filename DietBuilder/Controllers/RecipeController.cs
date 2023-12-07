using DietBuilder.Models.Meal;
using DietBuilder.Models.Recipe;
using DietBuilder.Services.Meal;
using DietBuilder.Services.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class RecipeController : Controller
	{
		private readonly IRecipeService _service;
		private readonly IMealService _mealService;

		public RecipeController(IRecipeService service,
								IMealService mealService)
		{
			_service = service;
			_mealService = mealService;
		}
		public async Task<IActionResult> Index()
		{
			var recipes = await _service.GetAllRecipesAsync();
			return View(recipes);
		}

		[Route("[controller]/{id}")]
		[ActionName("Details")]
		public async Task<IActionResult> Recipe(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var recipe = await _service.GetRecipeById(id);

			if (recipe is null)
				return RedirectToAction(nameof(Index));

			return View(recipe);
		}

		[HttpGet]
		[Route("[controller]/Create")]
		[Route("Meal/{mealId}/[controller]/Create")]
		public async Task<IActionResult> Create(int? mealId)
		{
			if (mealId is null || mealId == 0)
				return View(new RecipeCreate());

			var meal = await _mealService.GetMealById(mealId ?? 0);
			var model = new RecipeCreate(meal);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(RecipeCreate model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.CreateRecipeAsync(model);

			if (model.MealId > 0)
				return RedirectToAction("Details", "Meal", new {id = model.MealId});

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var recipe = await _service.GetRecipeById(id);

			if (recipe is null)
				return RedirectToAction(nameof(Index));

			var recipeEdit = new RecipeUpdate()
			{
				Id = recipe.Id,
				Name = recipe.Name,
				MealId = recipe.MealId,
				Calories = recipe.Calories,
				Carbs = recipe.Carbs,
				Protein = recipe.Protein
			};

			return View(recipeEdit);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(RecipeUpdate model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var recipe = await _service.UpdateRecipeAsync(model);

			if (!recipe)
				return RedirectToAction(nameof(Index));

			return RedirectToAction("Details", new { id = model.Id });
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var recipe = await _service.GetRecipeById(id);

			if (recipe is null)
				return RedirectToAction(nameof(Index));

			return View(recipe);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(RecipeDetail model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.DeleteRecipeAsync(model.Id);

			return RedirectToAction(nameof(Index));
		}
	}
}
