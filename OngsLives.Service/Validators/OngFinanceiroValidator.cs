using FluentValidation;
using OngsLives.Domain.Entidades;

namespace OngsLives.Service.Validators
{
    public class OngFinanceiroValidator : AbstractValidator<OngFinanceiro>
    {
        public OngFinanceiroValidator()
        {
            RuleFor(c => c.IdOng)
                .NotEmpty().WithMessage("Por favor, informe a Matricula da Ong.")
                .NotNull().WithMessage("Por favor, informe a Matricula da Ong.");

            RuleFor(c => c.Tipo)
                .NotEmpty().WithMessage("Por favor, informe o Tipo da Entrada")
                .NotNull().WithMessage("Por favor, informe o Tipo da Entrada");

            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("Por favor, informe a Data da Entrada")
                .NotNull().WithMessage("Por favor, informe a Data da Entrada");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("Por favor, informe o Valor")
                .NotNull().WithMessage("Por favor, informe o Valor");

            RuleFor(c => c.Origem)
                .NotEmpty().WithMessage("Por favor, informe a Origem")
                .NotNull().WithMessage("Por favor, informe a Origem");
        }
    }
}
