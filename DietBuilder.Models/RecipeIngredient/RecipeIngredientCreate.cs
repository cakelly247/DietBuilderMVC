using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Ingredient;
using DietBuilder.Models.Recipe;

namespace DietBuilder.Models.RecipeIngredient
{
	public class RecipeIngredientCreate
	{
		public RecipeDetail Recipe { get; set; }

		public List<int>? SelectedIngredientIds { get; set; }

        public List<IngredientListItem> Ingredients { get; set; }

        public int UnitOfMeasure { get; set; }

        public double QuantityOf { get; set; }
	}
}
