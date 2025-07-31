using BlogApi.Application.Posts;
using FluentValidation;

namespace BlogApi.WebApi.Validators
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Content).NotEmpty().MinimumLength(10);
        }
    }
}
