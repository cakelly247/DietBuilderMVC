using Microsoft.EntityFrameworkCore;
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
				Name = model.Name
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
				Name = ingredient.Name
			};
		}

		public async Task<bool> UpdateIngredientAsync(IngredientUpdate model)
		{
			IngredientEntity? ingredient = await _context.Ingredients.FindAsync(model.Id);

			if (ingredient is null)
				return false;

			ingredient.Id = model.Id;
			ingredient.Name = model.Name;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
