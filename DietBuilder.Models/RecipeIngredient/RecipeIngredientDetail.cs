using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data.Entities;

namespace DietBuilder.Models.RecipeIngredient
{
    public class RecipeIngredientDetail
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public IngredientEntity Ingredient { get; set; }

        public string Name
        {
            get
            {
                return Ingredient.Name;
            }
        }

        public double QuantityOf { get; set; }
    }
}