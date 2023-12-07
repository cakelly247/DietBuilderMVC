using Microsoft.EntityFrameworkCore;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Meal;
using DietBuilder.Models.Recipe;
using DietBuilder.Services.Recipe;

namespace DietBuilder.Services.Meal
{
	public class MealService : IMealService
	{
		private readonly DietBuilderDbContext _context;
		private readonly IRecipeService _recipeService;

		public MealService(DietBuilderDbContext context,
						   IRecipeService recipeService)
		{
			_context = context;
			_recipeService = recipeService;
		}

		public async Task<bool> CreateMealAsync(MealCreate model)
		{
			var meal = new MealEntity()
			{
				Name = model.Name,
				DietId = model.DietId ?? 0
			};

			_context.Meals.Add(meal);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<bool> DeleteMealAsync(int id)
		{
			var meal = await _context.Meals.FindAsync(id);

			if (meal is null)
				return false;

			_context.Meals.Remove(meal);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<List<MealListItem>> GetAllMealsAsync()
		{
			var meals = await _context.Meals
				.Select(m => new MealListItem()
				{
					Id = m.Id,
					Name = m.Name
				}).ToListAsync();

			return meals;
		}

		public Task<List<MealDetail>> GetAllMealsForDietAsync(int dietId)
		{
			return _context.Meals
				.Where(m => m.DietId == dietId)
				.Select(m => new MealDetail()
				{
					Id = m.Id,
					Name = m.Name
				}).ToListAsync();
		}

		public async Task<MealDetail?> GetMealById(int id)
		{
			var meal = await _context.Meals.FindAsync(id);

			if (meal is null)
				return null;

			var recipes = await _recipeService.GetAllRecipesForMealAsync(id);

			return new MealDetail()
			{
				Id = meal.Id,
				Name = meal.Name,
				Recipes = recipes
			};
		}

		public async Task<bool> UpdateMealAsync(MealUpdate model)
		{
			var meal = await _context.Meals.FindAsync(model.Id);

			if (meal is null)
				return false;

			meal.Id = model.Id;
			meal.Name = model.Name;
			meal.DietId = model.DietId;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
