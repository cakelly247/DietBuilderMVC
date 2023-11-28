using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Models.RecipeIngredient
{
	public class RecipeIngredientListItem
	{
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public string? IngredientName { get; set; }
        public double QuantityOf { get; set; }
    }
}
