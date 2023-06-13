using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OngsLives.Domain.Entidades;

namespace OngsLives.Domain.Entidades;

[Table("TB_Imagens")]
public class Imagem : BaseEntity
{
    public Imagem()
    {
            
    }
    public Imagem(
        int idDono, 
        string? nome,
        byte[]? conteudo
        )
    {
        Id = 0;
        IdDono = (idDono != null) ? idDono : 0;
        Nome = nome;
        Conteudo = conteudo;
        CriadoEm = DateTime.Now;
        Actived = true;
    }

    public int IdDono { get; set; }
    public string? Nome { get; set; }
    public byte[]? Conteudo { get; set; }
    public DateTime CriadoEm { get; set; }
}
