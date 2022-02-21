using FluentValidation;
using OrderApi.Musteri.Dtos.Musteri;

namespace OrderApi.Musteri.Validators
{
    public class CreateOrEditMusteriDtoValidator : AbstractValidator<CreateOrEditMusteriDto>
    {
        public CreateOrEditMusteriDtoValidator()
        {
            RuleFor(x => x.Ad)
                .NotEmpty()
                .MaximumLength(MusteriConsts.MaxAdLength);

            RuleFor(x => x.Soyad)
                .NotEmpty()
                .MaximumLength(MusteriConsts.MaxSoyadLength);
            
            RuleFor(x => x.Sehir)
                .MaximumLength(MusteriConsts.MaxSehirLength);
        }
    }
}