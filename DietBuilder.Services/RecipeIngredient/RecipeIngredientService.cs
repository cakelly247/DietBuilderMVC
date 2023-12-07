using Microsoft.EntityFrameworkCore;
using DietBuilder.Data;
using DietBuilder.Data.Entities;
using DietBuilder.Models.RecipeIngredient;
using DietBuilder.Services.Ingredient;

namespace DietBuilder.Services.RecipeIngredient
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly DietBuilderDbContext _context;
        private readonly IIngredientService _ingredientService;

        public RecipeIngredientService(DietBuilderDbContext context, IIngredientService ingredientService)
        {
            _context = context;
            _ingredientService = ingredientService;
        }

        public async Task<bool> CreateRecipeIngredientsAsync(RecipeIngredientCreate model)
        {
            foreach (var ingredient in model.Ingredients)
            {
                if (!ingredient.IsSelected)
                {
                    // Skip this ingredient
                    continue;
                }

                var recipeIngredient = new RecipeIngredientEntity()
                {
                    IngredientId = ingredient.Id,
                    RecipeId = model.RecipeId,
                    QuantityOf = model.QuantityOf,
                    Unit = (UnitOfMeasure)model.UnitOfMeasure
                };

                _context.RecipeIngredients.Add(recipeIngredient);
            }
            return await _context.SaveChangesAsync() == model.Ingredients.Count;
        }

        public async Task<bool> DeleteRecipeIngredientAsync(int id)
        {
            var recipeIngredient = await _context.RecipeIngredients.FindAsync(id);

            if (recipeIngredient is null)
                return false;

            _context.RecipeIngredients.Remove(recipeIngredient);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<List<RecipeIngredientListItem>?> GetAllRecipeIngredientsAsync()
        {
            var recipeIngredients = await _context.RecipeIngredients
                .Select(ri => new RecipeIngredientListItem()
                {
                    Id = ri.Id,
                    QuantityOf = ri.QuantityOf
                }).ToListAsync();

            return recipeIngredients;
        }

        public async Task<List<RecipeIngredientListItem>?> GetAllIngredientsForRecipeAsync(int recipeId)
        {
            var recipeIngredients = await _context.RecipeIngredients
                .Where(ri => ri.RecipeId == recipeId)
                .ToListAsync();

            var ingredients = new List<RecipeIngredientListItem>();
            foreach (var rIngredient in recipeIngredients)
            {
                var ingredient = await _ingredientService.GetIngredientById(rIngredient.IngredientId);
                ingredients.Add(new RecipeIngredientListItem()
                {
                    Id = rIngredient.Id,
                    Name = ingredient.Name,
                    QuantityOf = rIngredient.QuantityOf,
                    Unit = rIngredient.Unit.ToString()
                });
            }

            return ingredients;
        }

        public async Task<RecipeIngredientDetail?> GetRecipeIngredientById(int id)
        {
            var recipeIngredient = await _context.RecipeIngredients.FindAsync(id);

            if (recipeIngredient is null)
                return null;

            return new RecipeIngredientDetail()
            {
                Id = recipeIngredient.Id,
                RecipeId = recipeIngredient.RecipeId,
                QuantityOf = recipeIngredient.QuantityOf
            };
        }

        public async Task<bool> UpdateRecipeIngredientAsync(RecipeIngredientUpdate model)
        {
            var recipeIngredient = await _context.RecipeIngredients.FindAsync(model.Id);

            if (recipeIngredient is null)
                return false;

            recipeIngredient.Id = model.Id;
            recipeIngredient.QuantityOf = model.QuantityOf;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}