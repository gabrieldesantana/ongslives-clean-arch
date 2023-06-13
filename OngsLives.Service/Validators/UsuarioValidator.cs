using FluentValidation;
using OngsLives.Domain.Entidades;

namespace OngsLives.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, informe o Nome.")
                .NotNull().WithMessage("Por favor, informe o Nome");

            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("Por favor, informe o Login.")
                .NotNull().WithMessage("Por favor, informe o Login");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor, informe o Email.")
                .NotNull().WithMessage("Por favor, informe o Email");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Por favor, informe a Senha.")
                .NotNull().WithMessage("Por favor, informe a Senha");
        }
    }
}
