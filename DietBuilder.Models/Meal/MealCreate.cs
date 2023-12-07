using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Diet;

namespace DietBuilder.Models.Meal
{
	public class MealCreate
	{
        public MealCreate() { }

        public MealCreate(DietDetail? diet)
        {
            Diet = diet;
        }

		[Required, MaxLength(100)]
		public string? Name { get; set; }

        public int? DietId { get; set; }

        public DietDetail? Diet { get; }
    }
}
