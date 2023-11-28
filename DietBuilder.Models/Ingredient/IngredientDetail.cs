using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Models.Ingredient
{
	public class IngredientDetail
	{
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

		public double Calories { get; set; }

		public double Carbs { get; set; }

		public double Protein { get; set; }
	}
}
