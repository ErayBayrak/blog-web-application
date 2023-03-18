using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Geçilemez.");
            //RuleFor(x => x.WriterID).NotEmpty().WithMessage("Yazar Boş Geçilemez.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Resmi Boş Geçilemez.");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog Küçük Resmi Boş Geçilemez.");
            //RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Blog Başlığı Minimum 3 Karakter olmalıdır.").MaximumLength(50).WithMessage("Blog Başlığı" +
            //    "Maximum 500 Karakter Olabilir.");
            //RuleFor(x => x.BlogContent).MinimumLength(50).WithMessage("Blog İçeriği Minimum 3 Karakter olmalıdır.").MaximumLength(2500).WithMessage("Blog İçeriği" +
            //    "Maximum 2500 Karakter Olabilir.");
        }
    }
}
