using api.DTOs.Comment;
using FluentValidation;

namespace api.Validators.Comment
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDTO>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(5, 280).WithMessage("Title must be between 2 and 280 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .Length(10, 500).WithMessage("Content must be between 10 and 500 characters.");
        }
    }
}