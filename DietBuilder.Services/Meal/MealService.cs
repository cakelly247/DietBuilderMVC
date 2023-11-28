using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Meal;
using DietBuilder.Models.Recipe;

namespace DietBuilder.Services.Meal
{
	public class MealService : IMealService
	{
		private readonly DietBuilderDbContext _context;

		public MealService(DietBuilderDbContext context)
		{
			_context = context;
		}

		public async Task<bool> CreateMealAsync(MealCreate model)
		{
			var meal = new MealEntity()
			{
				Name = model.Name
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

		public async Task<List<MealListItem>>? GetAllMealsAsync()
		{
			var meals = await _context.Meals
				.Select(m => new MealListItem()
				{
					Id = m.Id,
					Name = m.Name
				}).ToListAsync();

			return meals;
		}

		public async Task<MealDetail?> GetMealById(int id)
		{
			var meal = await _context.Meals.FindAsync(id);

			if (meal is null)
				return null;

			return new MealDetail()
			{
				Id = meal.Id,
				Name = meal.Name,
				Recipes = new List<RecipeListItem>()
				.Select(r => new RecipeListItem()
				{
					Id = r.Id,
					Name = r.Name
				}).ToList()
			};
		}

		public async Task<bool> UpdateMealAsync(MealUpdate model)
		{
			var meal = await _context.Meals.FindAsync(model.Id);

			if (meal is null)
				return false;

			meal.Name = model.Name;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
