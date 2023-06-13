using FluentValidation;
using OngsLives.Domain.Entidades;

namespace OngsLives.Service.Validators
{
    public class ExperienciaValidator : AbstractValidator<Experiencia>
    {
        public ExperienciaValidator()
        {
            RuleFor(c => c.NomeVoluntario)
                .NotEmpty().WithMessage("Por favor, informe o Nome do Voluntario.")
                .NotNull().WithMessage("Por favor, informe o Nome do Voluntario.");

            RuleFor(c => c.NomeOng)
                .NotEmpty().WithMessage("Por favor, informe o Nome da Ong.")
                .NotNull().WithMessage("Por favor, informe o Nome da Ong.");

            RuleFor(c => c.ProjetoEnvolvido)
                .NotEmpty().WithMessage("Por favor, informe o Nome do Projeto.")
                .NotNull().WithMessage("Por favor, informe o Nome do Projeto.");

            RuleFor(c => c.Opiniao)
                .NotEmpty().WithMessage("Por favor, informe a sua Opinião.")
                .NotNull().WithMessage("Por favor, informe a sua Opinião.");

            RuleFor(c => c.Nota)
                .NotEmpty().WithMessage("Por favor, informe a Nota.")
                .NotNull().WithMessage("Por favor, informe a Nota.");

            RuleFor(c => c.DataExperienciaInicio)
                .NotEmpty().WithMessage("Por favor, informe a Data Inicio da Experiencia.")
                .NotNull().WithMessage("Por favor, informe o Nome do Voluntario.");

            RuleFor(c => c.DataExperienciaFim)
                .NotEmpty().WithMessage("Por favor, informe a Data Fim da Experiencia.")
                .NotNull().WithMessage("Por favor, informe a Data Fim da Experiencia.");
        }
    }
}
