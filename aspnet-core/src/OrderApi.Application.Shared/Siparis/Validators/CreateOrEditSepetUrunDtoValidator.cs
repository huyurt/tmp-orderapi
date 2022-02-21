using FluentValidation;
using OrderApi.Siparis.Dtos.SepetUrun;

namespace OrderApi.Siparis.Validators
{
    public class CreateOrEditSepetUrunDtoValidator : AbstractValidator<CreateOrEditSepetUrunDto>
    {
        public CreateOrEditSepetUrunDtoValidator()
        {
            RuleFor(x => x.Tutar)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Aciklama)
                .MaximumLength(SiparisUrunConsts.MaxAciklamaLength);
        }
    }
}