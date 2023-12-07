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

		public async Task<IActionResult> Index()
		{
			var diets = await _service.GetAllDietsAsync();
			return View(diets);
		}

		[Route("Create")]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create(DietCreate model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var diet = await _service.CreateDietAsync(model);
			return RedirectToAction("Details", new { id = diet.Id });
		}

		[Route("[controller]/{id}")]
		[ActionName("Details")]
		public async Task<IActionResult> Index(int id)
		{
			if (!ModelState.IsValid)
				return View();

			var diet = await _service.GetDietById(id);

			if (diet is null)
				return RedirectToAction(nameof(Index));

			return View("Details", diet);
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

		[HttpPost]
		public async Task<IActionResult> Edit(DietUpdate model)
		{
			if (!ModelState.IsValid)
				return View();

			var diet = await _service.UpdateDietAsync(model);

			if (!diet)
				return RedirectToAction(nameof(Index));

			return RedirectToAction("Details", new { id = model.Id });
		}


		public async Task<IActionResult> Delete(int id)
		{
			var diet = await _service.GetDietById(id);
			return View(diet);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(DietDetail model)
		{
			if (!ModelState.IsValid)
				return View();

			await _service.DeleteDietAsync(model.Id);
			return RedirectToAction(nameof(Index));
		}
	}
}