﻿using DietBuilder.Data.Entities;
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

		[ActionName("Details")]
		public async Task<IActionResult> Ingredient(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var ingredient = await _service.GetIngredientById(id);

			if (ingredient is null)
				return RedirectToAction(nameof(Index));

			return View(ingredient);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(IngredientCreate model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.CreateIngredientAsync(model);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var ingredient = await _service.GetIngredientById(id);

			if (ingredient is null)
				return RedirectToAction(nameof(Index));

			var ingredientEdit = new IngredientUpdate()
			{
				Id = ingredient.Id,
				Name = ingredient.Name
			};

			return View(ingredientEdit);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(IngredientUpdate model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			var ingredient = await _service.UpdateIngredientAsync(model);

			if (!ingredient)
				return RedirectToAction(nameof(Index));

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var ingredient = _service.GetIngredientById(id);

			if (ingredient is null)
				return RedirectToAction(nameof(Index));

			return View(ingredient);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(IngredientDetail model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.DeleteIngredientAsync(model.Id);

			return RedirectToAction(nameof(Index));
		}
	}
}
