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

  //      public async Task<IActionResult> Index()
		//{
		//	var recipeIngredients = await _service.GetAllRecipeIngredientsAsync();
		//	return View(recipeIngredients);
		//}

		public async Task<IActionResult> Index(int recipeId)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var recipe = await _recipeService.GetRecipeById(recipeId);

			//if (recipe is null)
			//	return RedirectToAction(nameof(Index));

			var recipeIngredients = recipe!.RecipeIngredients;

			return View(recipeIngredients);
		}

		[ActionName("Details")]
		public async Task<IActionResult> RecipeIngredient(int id)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var recipeIngredient = await _service.GetRecipeIngredientById(id);

			if (recipeIngredient is null)
				return RedirectToAction(nameof(Index));

			return View(recipeIngredient);
		}

		[HttpGet("Recipe/{recipeId}/Ingredients/Create")]
		public async Task<IActionResult> Create(int? recipeId)
		{
			if (recipeId is null || recipeId == 0)
				return View(new RecipeCreate());

			var model = new RecipeIngredientCreate()
			{
				Ingredients = await _ingredientService.GetAllIngredientsAsync(),
				Recipe = await _recipeService.GetRecipeById(recipeId ?? 0)
			};

			return View(model);  
		}

		[HttpPost("Recipe/{recipeId}/Ingredients/Create")]
		public async Task<IActionResult> Create(RecipeIngredientCreate model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.CreateRecipeIngredientAsync(model);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var recipeIngredient = await _service.GetRecipeIngredientById(id);

			if (recipeIngredient is null)
				return RedirectToAction(nameof(Index));

			var recipeIngredientEdit = new RecipeIngredientUpdate()
			{
				Id = recipeIngredient.Id,
				QuantityOf = recipeIngredient.QuantityOf
			};

			return View(recipeIngredientEdit);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(RecipeIngredientUpdate model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var recipeIngredient = await _service.UpdateRecipeIngredientAsync(model);

			if (!recipeIngredient)
				return RedirectToAction(nameof(Index));

			return RedirectToAction("Details", new { id = model.Id });
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var recipeIngredient = await _service.GetRecipeIngredientById(id);

			if (recipeIngredient is null)
				return RedirectToAction(nameof(Index));

			return View(recipeIngredient);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(RecipeIngredientDetail model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.DeleteRecipeIngredientAsync(model.Id);

			return RedirectToAction(nameof(Index));
		}
	}
}
