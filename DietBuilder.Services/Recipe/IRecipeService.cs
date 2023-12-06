using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Ingredient;
using DietBuilder.Models.Recipe;

namespace DietBuilder.Services.Recipe
{
	public interface IRecipeService
	{
		Task<bool> CreateRecipeAsync(RecipeCreate model);

		Task<List<RecipeListItem>> GetAllRecipesAsync();

		Task<List<RecipeListItem>> GetAllRecipesForMealAsync(int mealId);

		Task<RecipeDetail?> GetRecipeById(int id);

		Task<bool> UpdateRecipeAsync(RecipeUpdate model);

		Task<bool> DeleteRecipeAsync(int id);
	}
}
