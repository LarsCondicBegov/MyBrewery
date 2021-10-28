using MyBrewery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBrewery.Domain.Repositories.Recipes
{
    public interface IRecipeRepository : IRepositoryBase
    {
        Task<List<Recipe>> GetRecipesAsync(CancellationToken cancellationToken);
        Task<Recipe> GetRecipeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
