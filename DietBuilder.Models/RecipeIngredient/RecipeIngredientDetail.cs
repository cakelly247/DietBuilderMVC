using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Models.RecipeIngredient
{
	public class RecipeIngredientDetail
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IngredientId { get; set; }
        public string? RecipeName { get; set; }
        public int RecipeId { get; set; }
        public double QuantityOf { get; set; }
    }
}
