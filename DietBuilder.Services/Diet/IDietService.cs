using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietBuilder.Models.Diet;
using DietBuilder.Models.Ingredient;

namespace DietBuilder.Services.Diet
{
	public interface IDietService
	{
		Task<bool> CreateDietAsync(DietCreate model);

		Task<List<DietListItem>> GetAllDietsAsync();

		Task<DietDetail?> GetDietById(int id);

		Task<bool> UpdateDietAsync(DietUpdate model);

		Task<bool> DeleteDietAsync(int id);
	}
}
