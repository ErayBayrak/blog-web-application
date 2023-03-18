using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotNull().NotEmpty().WithMessage("Mail Boş Geçilemez").EmailAddress().WithMessage("Geçersiz Mail Formatı");
           
            //RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Resim Boş Geçilemez");

            RuleFor(x => x.WriterName).MinimumLength(5).WithMessage("Ad Soyad Minumum 5 karakter olabilir").MaximumLength(50).WithMessage("Ad Soyad Maximum 50 karakter olabilir.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden küçük olamaz.")
                .MaximumLength(16).WithMessage("Şifre 16 karakterden büyük olamaz.")
                .Matches(@"[A-Z]+").WithMessage("Şifrede en az bir büyük harf olmalıdır.")
                .Matches(@"[a-z]+").WithMessage("Şifrede en az bir küçük harf olmalıdır.")
                .Matches(@"[0-9]+").WithMessage("Şifrede en az bir rakam olmalıdır");
        }
    }
}
