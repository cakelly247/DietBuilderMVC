using Microsoft.EntityFrameworkCore;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.RecipeIngredient;

namespace DietBuilder.Services.RecipeIngredient
{
	public class RecipeIngredientService : IRecipeIngredientService
	{
		private readonly DietBuilderDbContext _context;

        public RecipeIngredientService(DietBuilderDbContext context)
        {
			_context = context;
        }

        public async Task<bool> CreateRecipeIngredientAsync(RecipeIngredientCreate model)
		{
            foreach (var ingredientId in model.SelectedIngredientIds)
            {
				var recipeIngredient = new RecipeIngredientEntity()
				{
					IngredientId = ingredientId,
					RecipeId = model.Recipe.Id,
					QuantityOf = model.QuantityOf,
					Unit = (UnitOfMeasure)model.UnitOfMeasure
				};

				_context.RecipeIngredients.Add(recipeIngredient);
            }
			return await _context.SaveChangesAsync() == model.SelectedIngredientIds.Count;
		}

		public async Task<bool> DeleteRecipeIngredientAsync(int id)
		{
			var recipeIngredient = await _context.RecipeIngredients.FindAsync(id);

			if (recipeIngredient is null)
				return false;

			_context.RecipeIngredients.Remove(recipeIngredient);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<List<RecipeIngredientListItem>?> GetAllRecipeIngredientsAsync()
		{
			var recipeIngredients = await _context.RecipeIngredients
				.Select(ri => new RecipeIngredientListItem()
				{
					Id = ri.Id,
					QuantityOf = ri.QuantityOf
				}).ToListAsync();

			return recipeIngredients;
		}

		public async Task<List<RecipeIngredientListItem>?> GetAllIngredientsForRecipeAsync(int recipeId)
		{
			var recipeIngredients = await _context.RecipeIngredients
				.Where(ri => ri.RecipeId == recipeId)
				.Select(ri => new RecipeIngredientListItem()
				{
					Id = ri.Id,
					QuantityOf = ri.QuantityOf
				}).ToListAsync();

			return recipeIngredients;
		}

		public async Task<RecipeIngredientDetail?> GetRecipeIngredientById(int id)
		{
			var recipeIngredient = await _context.RecipeIngredients.FindAsync(id);

			if (recipeIngredient is null)
				return null;

			return new RecipeIngredientDetail()
			{
				Id = recipeIngredient.Id,
				QuantityOf = recipeIngredient.QuantityOf
			};
		}

		public async Task<bool> UpdateRecipeIngredientAsync(RecipeIngredientUpdate model)
		{
			var recipeIngredient = await _context.RecipeIngredients.FindAsync(model.Id);

			if (recipeIngredient is null)
				return false;

			recipeIngredient.Id = model.Id;
			recipeIngredient.QuantityOf = model.QuantityOf;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
