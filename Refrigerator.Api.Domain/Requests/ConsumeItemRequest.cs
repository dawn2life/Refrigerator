using FluentValidation;

namespace Refrigerator.Api.Domain.Requests
{
    public class ConsumeItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class ConsumeItemRequestValidator : AbstractValidator<ConsumeItemRequest>
    {
        public ConsumeItemRequestValidator()
        {
            RuleFor(r => r.ProductId).NotEmpty().WithMessage("Product Id is required.");

            RuleFor(r => r.Quantity).NotEmpty().WithMessage("Quantity is required.");
        }
    }
}
