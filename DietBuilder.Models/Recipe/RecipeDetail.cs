using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.RecipeIngredient;

namespace DietBuilder.Models.Recipe
{
	public class RecipeDetail
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<RecipeIngredientListItem>? RecipeIngredients { get; set; }
        public int MealId { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Protein { get; set; }
    }
}
