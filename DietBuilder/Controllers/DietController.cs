using DietBuilder.Models.Diet;
using DietBuilder.Models.Responses;
using DietBuilder.Services.Diet;
using Microsoft.AspNetCore.Mvc;

namespace DietBuilder.Controllers
{
	public class DietController : Controller
	{
		private readonly IDietService _service;

        public DietController(IDietService service)
        {
			_service = service;
        }

        public IActionResult Index()
		{
			var diets = _service.GetAllDietsAsync();
			return View(diets);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(DietCreate model)
		{
			if (!ModelState.IsValid)
				return View(model);

			await _service.CreateDietAsync(model);
			return RedirectToAction(nameof(Index));
		}

		[ActionName("Details")]
		public async Task<IActionResult> Diet(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var diet = await _service.GetDietById(id);

			if (diet is null)
				return RedirectToAction(nameof(Index));

			return View(diet);
		}

		public async Task<IActionResult> Edit(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var diet = await _service.GetDietById(id);

			if (diet is null)
				return RedirectToAction(nameof(Index));

			var dietUpdate = new DietUpdate()
			{
				Id = diet.Id,
				Name = diet.Name,
				Description = diet.Description
			};

			return View(dietUpdate);
		}

		[HttpPut]
		public async Task<IActionResult> Edit(DietUpdate model)
		{
			if (!ModelState.IsValid)
				return View();

			var diet = await _service.UpdateDietAsync(model);

			if (diet is false)
				return RedirectToAction(nameof(Index));

			return RedirectToAction("Details", new { id = model.Id });
		}

		public IActionResult Delete(int id)
		{
			var diet = _service.GetDietById(id);
			return View(diet);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(DietDetail model)
		{
			if (!ModelState.IsValid)
				return View(ModelState);

			await _service.DeleteDietAsync(model.Id);
			return RedirectToAction(nameof(Index));
		}
	}
}
