using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Data.Entities
{
	public class RecipeEntity
	{
        [Key]
        public int Id { get; set; }

		[Required, MaxLength(100)]
		public string? Name { get; set; }

		public virtual List<RecipeIngredientEntity>? RecipeIngredients { get; set; }

        public double TotalCalories {
            get
            {
                return RecipeIngredients!.Count > 0 ? RecipeIngredients!.Select(r => r.IngredientCalories).Sum() : 0;
            }
        }

        public double TotalCarbs {
			get
			{
				return RecipeIngredients!.Count > 0 ? RecipeIngredients!.Select(r => r.IngredientCarbs).Sum() : 0;
			}
		}

		public double TotalProtein {
			get
			{
				return RecipeIngredients!.Count > 0 ? RecipeIngredients!.Select(r => r.IngredientProtein).Sum() : 0;
			}
		}
	}
}
