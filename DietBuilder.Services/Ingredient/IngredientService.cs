using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Ingredient;

namespace DietBuilder.Services.Ingredient
{
	public class IngredientService : IIngredientService
	{
		private readonly DietBuilderDbContext _context;

        public IngredientService(DietBuilderDbContext context)
        {
			_context = context;
        }

        public async Task<bool> CreateIngredientAsync(IngredientCreate model)
		{
			var ingredient = new IngredientEntity()
			{
				Name = model.Name,
				Calories = model.Calories,
				Carbs = model.Carbs,
				Protein = model.Protein
			};

			_context.Ingredients.Add(ingredient);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<bool> DeleteIngredientAsync(int id)
		{
			var ingredient = await _context.Ingredients.FindAsync(id);

			if (ingredient is null)
				return false;

			_context.Ingredients.Remove(ingredient);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<List<IngredientListItem>> GetAllIngredientsAsync()
		{
			List<IngredientListItem> ingredients = await _context.Ingredients
				.Select(i => new IngredientListItem()
				{
					Id = i.Id,
					Name = i.Name
				}).ToListAsync();

			return ingredients;
		}

		public async Task<IngredientDetail?> GetIngredientById(int id)
		{
			var ingredient = await _context.Ingredients.FindAsync(id);

			if (ingredient is null)
				return null;

			return new IngredientDetail()
			{
				Id = ingredient.Id,
				Name = ingredient.Name,
				Calories = ingredient.Calories,
				Carbs = ingredient.Carbs,
				Protein = ingredient.Protein
			};
		}

		public async Task<bool> UpdateIngredientAsync(IngredientUpdate model)
		{
			IngredientEntity? ingredient = await _context.Ingredients.FindAsync(model.Id);

			if (ingredient is null)
				return false;

			ingredient.Name = model.Name;
			ingredient.Calories = model.Calories;
			ingredient.Carbs = model.Carbs;
			ingredient.Protein = model.Protein;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
