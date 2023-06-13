using FluentValidation;
using OngsLives.Domain.Entidades;

namespace OngsLives.Service.Validators
{
    public class OngValidator : AbstractValidator<Ong>
    {
        public OngValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, informe o Nome.")
                .NotNull().WithMessage("Por favor, informe o Nome");

            RuleFor(c => c.CNPJ)
                .NotEmpty().WithMessage("Por favor, informe o CNPJ.")
                .NotNull().WithMessage("Por favor, informe o CNPJ.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Por favor, informe o Telefone.")
                .NotNull().WithMessage("Por favor, informe o Telefone.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor, informe o Email.")
                .NotNull().WithMessage("Por favor, informe o Email.");

            RuleFor(c => c.AreaAtuacao)
                .NotEmpty().WithMessage("Por favor, informe a Area de Atuacao.")
                .NotNull().WithMessage("Por favor, informe a Area de Atuacao.");

            RuleFor(c => c.QuantidadeEmpregados)
                .NotEmpty().WithMessage("Por favor, informe a Quantidade de Empregados")
                .NotNull().WithMessage("Por favor, informe a Quantidade de Empregados");

            RuleFor(c => c.Endereco).SetValidator(new EnderecoValidator());
        }
    }
}
