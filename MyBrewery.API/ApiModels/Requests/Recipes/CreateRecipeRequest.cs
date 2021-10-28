using FluentValidation;

namespace MyBrewery.API.ApiModels.Requests.Recipes
{
    public class CreateRecipeRequest
    {
        public int MyProperty { get; set; }
    }

    public class CreateRecipeRequestValidator : AbstractValidator<CreateRecipeRequest>
    {
        public CreateRecipeRequestValidator()
        {

        }
    }
}
