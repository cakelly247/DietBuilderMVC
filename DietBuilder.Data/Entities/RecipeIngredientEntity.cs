using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Data.Entities
{
    public class RecipeIngredientEntity
    {
        [Key]
        public int Id { get; set; }

        public string? Name {
            get
            {
                return Ingredient!.Name;
            }
        }

        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }

        public virtual IngredientEntity? Ingredient { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        public string? RecipeName {
            get
            {
                return Recipe!.Name;
            }
        }

        public virtual RecipeEntity? Recipe { get; set; }

        public double QuantityOf { get; set; }

        public double IngredientCalories {
            get
            {
                return Ingredient!.Calories * QuantityOf;
            }
        }

        public double IngredientCarbs {
            get
            {
                return Ingredient!.Carbs * QuantityOf;
            }
        }

		public double IngredientProtein { 
			get
			{
				return Ingredient!.Protein * QuantityOf;
			}
		}
	}
}
