using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Ingredient;
using DietBuilder.Models.Meal;

namespace DietBuilder.Services.Meal
{
	public interface IMealService
	{
		Task<bool> CreateMealAsync(MealCreate model);

		Task<List<MealListItem>>? GetAllMealsAsync();

		Task<MealDetail?> GetMealById(int id);

		Task<bool> UpdateMealAsync(MealUpdate model);

		Task<bool> DeleteMealAsync(int id);
	}
}
