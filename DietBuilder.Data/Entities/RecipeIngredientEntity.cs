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

        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }

        public virtual IngredientEntity? Ingredient { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        public virtual RecipeEntity? Recipe { get; set; }

        public double QuantityOf { get; set; }

        public UnitOfMeasure Unit { get; set; }
    }

    public enum UnitOfMeasure
    {
        None,
        Gram,
        Ounce,
        Pound,
        Cup,
        Tbsp,
        Tsp
    }
}
