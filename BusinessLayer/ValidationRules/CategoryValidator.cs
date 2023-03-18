using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş geçilemez.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori içeriği boş geçilemez.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı 50 karakteri geçemez.");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori adı 2 karakterden az olamaz.");
            RuleFor(x => x.CategoryDescription).MaximumLength(500).WithMessage("Kategori içeriği 500 karakteri geçemez.");
            RuleFor(x => x.CategoryDescription).MinimumLength(3).WithMessage("Kategori içeriği 3 karakterden az olamaz.");
        }
    }
}
