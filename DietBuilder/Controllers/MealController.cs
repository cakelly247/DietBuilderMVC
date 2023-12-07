using DietBuilder.Models.Meal;
using DietBuilder.Services.Diet;
using DietBuilder.Services.Meal;
using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class MealController : Controller
	{
		private readonly IMealService _service;
		private readonly IDietService _dietService;

		public MealController(IMealService service,
							  IDietService dietService)
		{
			_service = service;
			_dietService = dietService;
		}

		public async Task<IActionResult> Index()
		{
			var meals = await _service.GetAllMealsAsync();
			return View(meals);
		}

		[Route("[controller]/{id}")]
		[ActionName("Details")]
		public async Task<IActionResult> Meal(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var meal = await _service.GetMealById(id);

			if (meal is null)
				return RedirectToAction(nameof(Index));

			return View(meal);
		}

		[HttpGet]
		[Route("[controller]/Create")]
		[Route("Diet/{dietId}/[controller]/Create")]
		public async Task<IActionResult> Create(int? dietId)
		{
			if (dietId is null || dietId == 0)
				return View(new MealCreate());

			var diet = await _dietService.GetDietById(dietId ?? 0);
			var model = new MealCreate(diet);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(MealCreate model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.CreateMealAsync(model);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var meal = await _service.GetMealById(id);

			if (meal is null)
				return RedirectToAction(nameof(Index));

			var mealEdit = new MealUpdate()
			{
				Id = meal.Id,
				Name = meal.Name
			};

			return View(mealEdit);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(MealUpdate model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var meal = await _service.UpdateMealAsync(model);

			if (!meal)
				return RedirectToAction(nameof(Index));

			return RedirectToAction("Details", new { id = model.Id });
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var meal = await _service.GetMealById(id);

			if (meal is null)
				return RedirectToAction(nameof(Index));

			return View(meal);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(MealDetail model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.DeleteMealAsync(model.Id);

			return RedirectToAction(nameof(Index));
		}
	}
}
