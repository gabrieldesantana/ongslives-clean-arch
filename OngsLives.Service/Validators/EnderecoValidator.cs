using FluentValidation;
using OngsLives.Domain.Entidades;

namespace OngsLives.Service.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(c => c.EnderecoLinha)
                .NotEmpty().WithMessage("Por favor, informe o Logradouro.")
                .NotNull().WithMessage("Por favor, informe o logradouro.");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("Por favor, informe o Numero.")
                .NotNull().WithMessage("Por favor, informe o Numero.");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("Por favor, informe o Cep.")
                .NotNull().WithMessage("Por favor, informe o Cep.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Por favor, informe o Bairro.")
                .NotNull().WithMessage("Por favor, informe o Bairro.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Por favor, informe a Cidade.")
                .NotNull().WithMessage("Por favor, informe a Cidade.");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Por favor, informe o Estado.")
                .NotNull().WithMessage("Por favor, informe o Estado.");

            RuleFor(c => c.Pais)
                .NotEmpty().WithMessage("Por favor, informe o Pais.")
                .NotNull().WithMessage("Por favor, informe o Pais.");
        }
    }
}
