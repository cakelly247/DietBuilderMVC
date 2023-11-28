using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Models.RecipeIngredient
{
	public class RecipeIngredientCreate
	{
		public int RecipeId { get; set; }

		public int IngredientId { get; set; }

		public double QuantityOf { get; set; }
	}
}
