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
        public double TotalCalories { get; set; }
        public double TotalCarbs { get; set; }
        public double TotalProtein { get; set; }
    }
}
