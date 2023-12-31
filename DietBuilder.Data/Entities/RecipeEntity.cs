﻿using System;
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

        public int? MealId { get; set; }

		public virtual List<RecipeIngredientEntity>? RecipeIngredients { get; set; }

        public double Calories { get; set; }

        public double Carbs { get; set; }
		
		public double Protein { get; set; }
	}
}
