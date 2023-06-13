using OngsLives.Domain.Entidades;

namespace OngsLives.Domain.Interfaces.Repository;
public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    public Task<Usuario> GetByEmailAsync(string email);
}