using ApiProjeWeb.Entities;
using FluentValidation;

namespace ApiProjeWeb.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product> //kalıp
    {
        public ProductValidator()  // validation klaıpları
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Lütfen ürün adını boş geçmeyin")
                .MinimumLength(2).WithMessage("En az 2 karakter girişi yapın!")
                .MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapın!");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Ürün fiyatı boş geçilemez!!")
                .LessThan(5000).WithMessage("Ürün fiyatı 5000 büyük olamaz!")
                .GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz");

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("Ürün açıklaması boş geçilemez!")
                .MaximumLength(22).WithMessage("Ürün açıklaması minimum 22 karakter girişli olmalı")
                .MaximumLength(500).WithMessage("Ürüm açıklaması maximum 500 karakter girişli olmalı");
        }
    }
}
