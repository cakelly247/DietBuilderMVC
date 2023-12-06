using Microsoft.EntityFrameworkCore;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Recipe;
using DietBuilder.Models.RecipeIngredient;

namespace DietBuilder.Services.Recipe
{
	public class RecipeService : IRecipeService
	{
		private readonly DietBuilderDbContext _context;

		public RecipeService(DietBuilderDbContext context)
		{
			_context = context;
		}
		public async Task<bool> CreateRecipeAsync(RecipeCreate model)
		{
			var recipe = new RecipeEntity()
			{
				Name = model.Name,
				MealId = model.MealId,
				Calories = model.Calories,
				Carbs = model.Carbs,
				Protein = model.Protein
			};

			_context.Recipes.Add(recipe);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<bool> DeleteRecipeAsync(int id)
		{
			var recipe = await _context.Recipes.FindAsync(id);

			if (recipe is null)
				return false;

			_context.Recipes.Remove(recipe);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<List<RecipeListItem>> GetAllRecipesAsync()
		{
			var recipes = await _context.Recipes
				.Select(r => new RecipeListItem()
				{
					Id = r.Id,
					Name = r.Name
				}).ToListAsync();

			return recipes;
		}

		public Task<List<RecipeListItem>> GetAllRecipesForMealAsync(int mealId)
		{
			return _context.Recipes
				.Where(r => r.MealId == mealId)
				.Select(r => new RecipeListItem()
				{
					Id = r.Id,
					Name = r.Name
				}).ToListAsync();
		}

		public async Task<RecipeDetail?> GetRecipeById(int id)
		{
			var recipe = await _context.Recipes.FindAsync(id);

			if (recipe is null)
				return null;

			return new RecipeDetail()
			{
				Id = recipe.Id,
				Name = recipe.Name,
				RecipeIngredients = new List<RecipeIngredientListItem>()
				.Select(ri => new RecipeIngredientListItem()
				{
					Name = ri.Name,
					QuantityOf = ri.QuantityOf
				}).ToList(),
				MealId = recipe.MealId ?? 0,
				Calories = recipe.Calories,
				Carbs = recipe.Carbs,
				Protein = recipe.Protein
			};
		}

		public async Task<bool> UpdateRecipeAsync(RecipeUpdate model)
		{
			var recipe = await _context.Recipes.FindAsync(model.Id);

			if (recipe is null)
				return false;

			recipe.Id = model.Id;
			recipe.Name = model.Name;
			recipe.MealId = model.MealId;
			recipe.Calories = model.Calories;
			recipe.Carbs = model.Carbs;
			recipe.Protein = model.Protein;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
