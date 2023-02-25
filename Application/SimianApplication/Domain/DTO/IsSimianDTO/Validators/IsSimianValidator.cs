using FluentValidation;

namespace Domain.DTO.IsSimianDTO.Validators
{
    internal class IsSimianValidator : AbstractValidator<IsSimianRequestDTO>
    {
        public IsSimianValidator()
        {
            RuleFor(a => a.Dna)
                .ChildRules(x =>
                {
                    x.RuleForEach(x => x).MinimumLength(7).WithMessage("Cadeia de Dna's devem ter 6 elementos"); ;
                })
                .NotEmpty()
                .WithMessage("Dna não pode ser vazio");

            


        }
    }
}
