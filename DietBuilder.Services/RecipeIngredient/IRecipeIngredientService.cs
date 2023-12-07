using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Ingredient;
using DietBuilder.Models.RecipeIngredient;

namespace DietBuilder.Services.RecipeIngredient
{
	public interface IRecipeIngredientService
	{
		Task<bool> CreateRecipeIngredientAsync(RecipeIngredientCreate model);

		Task<List<RecipeIngredientListItem>?> GetAllRecipeIngredientsAsync();

		Task<List<RecipeIngredientListItem>?> GetAllIngredientsForRecipeAsync(int recipeId);

		Task<RecipeIngredientDetail?> GetRecipeIngredientById(int id);

		Task<bool> UpdateRecipeIngredientAsync(RecipeIngredientUpdate model);

		Task<bool> DeleteRecipeIngredientAsync(int id);
	}
}
