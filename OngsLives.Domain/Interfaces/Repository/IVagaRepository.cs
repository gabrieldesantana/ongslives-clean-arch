using OngsLives.Domain.Entidades;

namespace OngsLives.Domain.Interfaces.Repository;
public interface IVagaRepository : IGenericRepository<Vaga>
{
    Task<List<Vaga>> GetVagasAsync(int idOng);
}