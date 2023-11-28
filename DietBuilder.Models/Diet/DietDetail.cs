using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Meal;

namespace DietBuilder.Models.Diet
{
	public class DietDetail
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<MealListItem>? Meals { get; set; }
    }
}
