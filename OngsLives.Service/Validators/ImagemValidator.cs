using FluentValidation;
using OngsLives.Domain.Entidades;

namespace OngsLives.Service.Validators
{
    public class ImagemValidator : AbstractValidator<Imagem>
    {
        public ImagemValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, informe o Nome.")
                .NotNull().WithMessage("Por favor, informe o Nome.");

            RuleFor(c => c.Conteudo)
                .NotEmpty().WithMessage("Por favor, insira uma imagem.")
                .NotNull().WithMessage("Por favor, insira uma imagem.");
        }
    }
}
