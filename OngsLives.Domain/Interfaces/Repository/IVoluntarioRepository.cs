using OngsLives.Domain.Entidades;

namespace OngsLives.Domain.Interfaces.Repository;
public interface IVoluntarioRepository : IGenericRepository<Voluntario>
{
    public Task<Voluntario> GetByNomeAsync(string nome);
    public Task<Voluntario> GetByEmailAsync(string email);
}