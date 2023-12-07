using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Diet;
using DietBuilder.Models.Meal;

namespace DietBuilder.Models.Recipe
{
	public class RecipeCreate
	{
        public RecipeCreate() { }

        public RecipeCreate(MealDetail? meal)
        {
            Meal = meal;
        }

		[Required, MaxLength(100)]
		public string? Name { get; set; }

        public int? MealId { get; set; }

        public MealDetail? Meal { get; set; }

        public double Calories { get; set; }

		public double Carbs { get; set; }

		public double Protein { get; set; }
	}
}
