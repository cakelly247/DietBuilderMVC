﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.RecipeIngredient;

namespace DietBuilder.Services.RecipeIngredient
{
	public class RecipeIngredientService : IRecipeIngredientService
	{
		private readonly DietBuilderDbContext _context;

        public RecipeIngredientService(DietBuilderDbContext context)
        {
			_context = context;
        }

        public async Task<bool> CreateRecipeIngredientAsync(RecipeIngredientCreate model)
		{
			var recipeIngredient = new RecipeIngredientEntity()
			{
				IngredientId = model.IngredientId,
				RecipeId = model.RecipeId,
				QuantityOf = model.QuantityOf
			};

			_context.RecipeIngredients.Add(recipeIngredient);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<bool> DeleteRecipeIngredientAsync(int id)
		{
			var recipeIngredient = await _context.RecipeIngredients.FindAsync(id);

			if (recipeIngredient is null)
				return false;

			_context.RecipeIngredients.Remove(recipeIngredient);
			return await _context.SaveChangesAsync() == 1;
		}

		public async Task<List<RecipeIngredientListItem>?> GetAllRecipeIngredientsAsync(int recipeId)
		{
			var recipeIngredients = await _context.RecipeIngredients
				.Where(ri => ri.RecipeId == recipeId)
				.Select(ri => new RecipeIngredientListItem()
				{
					Id = ri.Id,
					IngredientId = ri.IngredientId,
					IngredientName = ri.Name,
					QuantityOf = ri.QuantityOf
				}).ToListAsync();

			return recipeIngredients;
		}

		public async Task<RecipeIngredientDetail?> GetRecipeIngredientById(int id)
		{
			var recipeIngredient = await _context.RecipeIngredients.FindAsync(id);

			if (recipeIngredient is null)
				return null;

			return new RecipeIngredientDetail()
			{
				Id = recipeIngredient.Id,
				IngredientId = recipeIngredient.IngredientId,
				Name = recipeIngredient.Name,
				RecipeId = recipeIngredient.RecipeId,
				RecipeName = recipeIngredient.RecipeName,
				QuantityOf = recipeIngredient.QuantityOf
			};
		}

		public async Task<bool> UpdateRecipeIngredientAsync(RecipeIngredientUpdate model)
		{
			var recipeIngredient = await _context.RecipeIngredients.FindAsync(model.Id);

			if (recipeIngredient is null)
				return false;

			recipeIngredient.QuantityOf = model.QuantityOf;
			return await _context.SaveChangesAsync() == 1;
		}
	}
}
