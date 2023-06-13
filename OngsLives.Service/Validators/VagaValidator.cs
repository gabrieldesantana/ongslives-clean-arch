using FluentValidation;
using OngsLives.Domain.Entidades;

namespace OngsLives.Service.Validators
{
    public class VagaValidator : AbstractValidator<Vaga>
    {
        public VagaValidator()
        {
            RuleFor(c => c.IdOng)
                .NotEmpty().WithMessage("Por favor, informe a Matricula da Ong.")
                .NotNull().WithMessage("Por favor, informe a Matricula da Ong.");

            RuleFor(c => c.Tipo)
                .NotEmpty().WithMessage("Por favor, informe o Tipo.")
                .NotNull().WithMessage("Por favor, informe o Tipo.");

            RuleFor(c => c.Turno)
                .NotEmpty().WithMessage("Por favor, informe o Turno.")
                .NotNull().WithMessage("Por favor, informe o Turno.");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Por favor, informe a Descricao.")
                .NotNull().WithMessage("Por favor, informe a Descricao.");

            RuleFor(c => c.Habilidade)
                .NotEmpty().WithMessage("Por favor, informe a Habilidade.")
                .NotNull().WithMessage("Por favor, informe a Habilidade.");

            RuleFor(c => c.DataInicio)
                .NotEmpty().WithMessage("Por favor, informe a Data Inicio.")
                .NotNull().WithMessage("Por favor, informe a Data Inicio.");

            RuleFor(c => c.DataFim)
                .NotEmpty().WithMessage("Por favor, informe a Data Fim.")
                .NotNull().WithMessage("Por favor, informe a Data Fim.");
        }
    }
}
