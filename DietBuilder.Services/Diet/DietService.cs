using System;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.Diet;
using DietBuilder.Models.Meal;
using DietBuilder.Services.Meal;
using Microsoft.EntityFrameworkCore;

namespace DietBuilder.Services.Diet
{
	public class DietService : IDietService
	{
		private readonly DietBuilderDbContext _context;
		private readonly IMealService _mealService;

		public DietService(DietBuilderDbContext context, IMealService mealService)
		{
			_context = context;
			_mealService = mealService;
		}

		public async Task<DietDetail?> CreateDietAsync(DietCreate model)
		{
			DietEntity diet = new DietEntity()
			{
				Name = model.Name,
				Description = model.Description
			};

			_context.Diets.Add(diet);
			await _context.SaveChangesAsync();

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
			var meals = await _mealService.GetAllMealsForDietAsync(id);
			var diet = await _context.Diets
				.Select(d => new DietDetail()
				{
					Id = d.Id,
					Name = d.Name,
					Description = d.Description,
					Meals = meals
					.Select(m => new MealListItem()
					{
						Id = m.Id,
						Name = m.Name
					}).ToList()
				})
				.FirstOrDefaultAsync(d => d.Id == id);
				//.ToListAsync();

			if (diet is null)
				return null;

			return diet;

			//return new DietDetail()
			//{
			//	Id = diet.Id,
			//	Name = diet.Name,
			//	Description = diet.Description,
			//	Meals = new List<MealListItem>()
			//	.Select(m => new MealListItem()
			//	{
			//		Id = m.Id,
			//		Name = m.Name
			//	}).ToList()
			//};
		}

		public async Task<bool> UpdateDietAsync(DietUpdate model)
		{
			var diet = await _context.Diets.FindAsync(model.Id);

			if (diet is null)
				return false;

			diet.Id = model.Id;
			diet.Name = model.Name;
			diet.Description = model.Description;

			return await _context.SaveChangesAsync() == 1;
		}
	}
}
