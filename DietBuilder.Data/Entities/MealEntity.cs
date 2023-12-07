using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Data.Entities
{
	public class MealEntity
	{
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }

        public int? DietId { get; set; }

        public List<RecipeEntity>? Recipes { get; set; }

        public double TotalCalories
		{
			get
			{
				return Recipes!.Count > 0 ? Recipes.Select(r => r.Calories).Sum() : 0;
			}
		}

		public double TotalCarbs
		{
			get
			{
				return Recipes!.Count > 0 ? Recipes.Select(r => r.Carbs).Sum() : 0;
			}
		}

		public double TotalProtein
        { 
            get
            {
                return Recipes!.Count > 0 ? Recipes.Select(r => r.Protein).Sum() : 0;
            }
        }
    }
}
