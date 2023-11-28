using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Recipe;

namespace DietBuilder.Models.Meal
{
	public class MealDetail
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<RecipeListItem>? Recipes { get; set; }
    }
}
