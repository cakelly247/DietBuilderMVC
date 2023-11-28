using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietBuilder.Data
{
	public class DietBuilderDbContext : DbContext
	{
        public DietBuilderDbContext() { }
        public DietBuilderDbContext(DbContextOptions<DietBuilderDbContext> options) : base(options)
        {

        }

        public virtual DbSet<DietEntity> Diets { get; set; }

        public virtual DbSet<IngredientEntity> Ingredients { get; set; }

        public virtual DbSet<MealEntity> Meals { get; set; }

        public virtual DbSet<RecipeEntity> Recipes { get; set; }

        public virtual DbSet<RecipeIngredientEntity> RecipeIngredients { get; set; }

        public virtual DbSet<UserEntity> Users { get; set; }
	}
}
