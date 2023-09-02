using FluentValidation;

namespace Refrigerator.Api.Domain.Requests
{
    public class AddItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class AddItemRequestValidator : AbstractValidator<AddItemRequest>
    {
        public AddItemRequestValidator()
        {
            RuleFor(r => r.ProductId).NotEmpty().WithMessage("Product Id is required.");

            RuleFor(r => r.Quantity).NotEmpty().WithMessage("Quantity is required.");
        }
    }
}
