using OngsLives.Domain.Entidades;

namespace OngsLives.Domain.Models.EditModels;

public class EditOngModel 
{
        public int Id { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public int QuantidadeEmpregados { get; set; }
        public Endereco? Endereco { get; set; }
}