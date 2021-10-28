using Microsoft.EntityFrameworkCore;
using MyBrewery.Domain.Models;
using MyBrewery.Domain.Repositories.Recipes;
using MyBrewery.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBrewery.Application.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(MyBreweryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Recipe>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            var recipes = await _dbSet.ToListAsync(cancellationToken);

            return recipes;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id, CancellationToken cancellationToken)
        {
            var recipe = await _dbSet.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

            return recipe;
        }
    }
}
