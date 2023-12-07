using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Ingredient;
using DietBuilder.Models.Recipe;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DietBuilder.Models.RecipeIngredient
{
    public class RecipeIngredientCreate
    {
        [ValidateNever]
        public RecipeDetail Recipe { get; set; }

        public int RecipeId { get; set; }

        public List<IngredientChecked> Ingredients { get; set; }

        public int UnitOfMeasure { get; set; }

        public double QuantityOf { get; set; }
    }

    public class IngredientChecked
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsSelected { get; set; }
    }
}