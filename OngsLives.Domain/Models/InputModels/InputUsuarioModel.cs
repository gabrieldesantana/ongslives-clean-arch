using OngsLives.Domain.Enums;

namespace OngsLives.Domain.Models.InputModels;

public class InputUsuarioModel 
{
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public EPerfilUsuario? Perfil { get; set; }
        // public DateTime? CriadoEm { get; set; }
}