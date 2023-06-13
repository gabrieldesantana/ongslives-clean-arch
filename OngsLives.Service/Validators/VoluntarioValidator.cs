using FluentValidation;
using OngsLives.Domain.Entidades;

namespace OngsLives.Service.Validators
{
    public class VoluntarioValidator : AbstractValidator<Voluntario>
    {
        public VoluntarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, informe o Nome.")
                .NotNull().WithMessage("Por favor, informe o Nome.");

            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("Por favor, informe o CPF.")
                .NotNull().WithMessage("Por favor, informe o CPF.");

            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("Por favor, informe a Data de Nascimento.")
                .NotNull().WithMessage("Por favor, informe a Data de Nascimento.");

            RuleFor(c => c.Escolaridade)
                .NotEmpty().WithMessage("Por favor, informe a Escolaridade.")
                .NotNull().WithMessage("Por favor, informe a Escolaridade.");

            RuleFor(c => c.Genero)
                .NotEmpty().WithMessage("Por favor, informe o Genero.")
                .NotNull().WithMessage("Por favor, informe o Genero.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor, informe o Email.")
                .NotNull().WithMessage("Por favor, informe o Email.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Por favor, informe o Telefone.")
                .NotNull().WithMessage("Por favor, informe o Telefone.");

            RuleFor(c => c.Habilidade)
                .NotEmpty().WithMessage("Por favor, informe a Habilidade.")
                .NotNull().WithMessage("Por favor, informe a Habilidade.");

            RuleFor(c => c.Endereco).SetValidator(new EnderecoValidator());
        }
    }
}
