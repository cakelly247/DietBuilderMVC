using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				Name = model.Name
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

		public async Task<List<RecipeListItem>>? GetAllRecipesAsync()
		{
			var recipes = await _context.Recipes
				.Select(r => new RecipeListItem()
				{
					Id = r.Id,
					Name = r.Name
				}).ToListAsync();

			return recipes;
		}

		public async Task<RecipeDetail?> GetRecipeById(int id)
		{
			var recipe = await _context.Recipes.FindAsync(id);

			if (recipe is null)
				return null;

			return new RecipeDetail()
			{
				Name = recipe.Name,
				RecipeIngredients = new List<RecipeIngredientListItem>()
				.Select(ri => new RecipeIngredientListItem()
				{
					IngredientId = ri.IngredientId,
					IngredientName = ri.IngredientName,
					QuantityOf = ri.QuantityOf
				}).ToList(),
				TotalCalories = recipe.TotalCalories,
				TotalCarbs = recipe.TotalCarbs,
				TotalProtein = recipe.TotalProtein
			};
		}

		public async Task<bool> UpdateRecipeAsync(RecipeUpdate model)
		{
			var recipe = await _context.Recipes.FindAsync(model.Id);

			if (recipe is null)
				return false;

			recipe.Name = model.Name;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
