using AutoMapper;
using MyBrewery.API.ApiModels.Responses.Recipes;
using MyBrewery.Domain.Models;

namespace MyBrewery.API.Mapping.Recipes
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeResponse>(MemberList.Destination);
        }
    }
}
