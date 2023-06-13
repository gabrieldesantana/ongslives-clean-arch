using OngsLives.Domain.Entidades;

namespace OngsLives.Domain.Interfaces.Repository;
public interface IOngRepository : IGenericRepository<Ong>
{
    public Task<Ong> GetByNomeAsync(string nome);
    public Task<Ong> GetByEmailAsync(string email);
    // public void AdicionarVaga(Ong ong);
    // public void AdicionarFinanceiro(Ong ong);
    // public void AdicionarFoto(Ong ong);
    // public void AdicionarPropriedade(Ong ong);
}