using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBrewery.API.ApiModels.Responses.Recipes;
using MyBrewery.API.Controllers;
using MyBrewery.Domain.Models;
using MyBrewery.Domain.Repositories.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MyBreweryAPI.Controllers.Recipes
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : BaseController<RecipesController>
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipesController(IRecipeRepository recipeRepository, IMapper mapper, IMediator mediator, ILogger <RecipesController> logger)
            :base(mapper, mediator, logger)
        {
            _recipeRepository = recipeRepository;
        }

        /// <summary>
        /// Get recipes.
        /// </summary>
        /// <returns>List of recipes.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest/*, Type = typeof()*/)]
        public async Task<ActionResult<List<RecipeResponse>>> GetRecipes(CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetRecipesAsync(cancellationToken);

            var mapped = _mapper.Map<List<RecipeResponse>>(recipes);

            return mapped;
        }

        /// <summary>
        /// Get a recipe by its id.
        /// </summary>
        /// <parameters>id</parameters>
        /// <returns>The recipe with given id</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest/*, Type = typeof()*/)]
        public async Task<ActionResult<RecipeResponse>> GetRecipeById(int id, CancellationToken cancellationToken)
        {
            var recipes = await _recipeRepository.GetRecipeByIdAsync(id, cancellationToken);

            var mapped = _mapper.Map<RecipeResponse>(recipes);

            return mapped;
        }
    }
}
