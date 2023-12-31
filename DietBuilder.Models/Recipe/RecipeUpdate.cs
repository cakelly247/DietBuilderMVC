﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietBuilder.Models.Recipe
{
	public class RecipeUpdate
	{
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? MealId { get; set; }

        public double Calories { get; set; }

		public double Carbs { get; set; }

		public double Protein { get; set; }
	}
}
