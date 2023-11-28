using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Diet;
using DietBuilder.Models.Meal;

namespace DietBuilder.Services.Diet
{
	public class DietService : IDietService
	{
		private readonly DietBuilderDbContext _context;

        public DietService(DietBuilderDbContext context)
        {
			_context = context;
        }

        public async Task<bool> CreateDietAsync(DietCreate model)
		{
			DietEntity diet = new DietEntity()
			{
				Name = model.Name,
				Description = model.Description
			};

			_context.Diets.Add(diet);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<bool> DeleteDietAsync(int id)
		{
			var diet = await _context.Diets.FindAsync(id);

			if (diet is null)
				return false;

			_context.Diets.Remove(diet);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<List<DietListItem>> GetAllDietsAsync()
		{
			var diets = await _context.Diets
				.Select(d => new DietListItem()
				{
					Id = d.Id,
					Name = d.Name
				}).ToListAsync();

			return diets;
		}

		public async Task<DietDetail?> GetDietById(int id)
		{
			var diet = await _context.Diets.FindAsync(id);

			if (diet is null)
				return null;

			return new DietDetail()
			{
				Id = diet.Id,
				Name = diet.Name,
				Description = diet.Description,
				Meals = new List<MealListItem>()
				.Select(m => new MealListItem()
				{
					Id = m.Id,
					Name = m.Name
				}).ToList()
			};
		}

		public async Task<bool> UpdateDietAsync(DietUpdate model)
		{
			var diet = await _context.Diets.FindAsync(model.Id);

			if (diet is null)
				return false;

			diet.Name = model.Name;
			diet.Description = model.Description;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
