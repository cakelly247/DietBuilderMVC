using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data;
using DietBuilder.Models.Ingredient;

namespace DietBuilder.Services.Ingredient
{
	public interface IIngredientService
	{
		Task<bool> CreateIngredientAsync(IngredientCreate model);

		Task<List<IngredientListItem>> GetAllIngredientsAsync();

		Task<IngredientDetail?> GetIngredientById(int id);

		Task<bool> UpdateIngredientAsync(IngredientUpdate model);

		Task<bool> DeleteIngredientAsync(int id);
    }
}
