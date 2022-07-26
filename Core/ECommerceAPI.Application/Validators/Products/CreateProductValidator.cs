using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
             .NotEmpty()
             .NotNull()
                .WithMessage("Please fill name section")
             .MaximumLength(150)
             .MinimumLength(2)
                .WithMessage("Please fill name section 2 and 150 range");

            RuleFor(p => p.Stock)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Please fill stock section")
                .Must(s => s >= 0)
                    .WithMessage("Stock must be bigger than 0");

            RuleFor(p => p.Price)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Please fill price section")
                .Must(s => s >= 0)
                    .WithMessage("Price must be bigger than 0");
        }
    }
}
