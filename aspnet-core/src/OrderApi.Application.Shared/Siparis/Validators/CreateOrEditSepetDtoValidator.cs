using FluentValidation;
using OrderApi.Siparis.Dtos.Sepet;

namespace OrderApi.Siparis.Validators
{
    public class CreateOrEditSepetDtoValidator : AbstractValidator<CreateOrEditSepetDto>
    {
        public CreateOrEditSepetDtoValidator()
        {
            RuleForEach(x => x.SepetUrunler)
                .SetValidator(x => new CreateOrEditSepetUrunDtoValidator());
        }
    }
}