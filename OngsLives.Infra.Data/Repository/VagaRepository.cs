using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;

public class VagaRepository : GenericRepository<Vaga>, IVagaRepository
{
    public VagaRepository(OngLivesContext context, IUnitOfWork unitOfWork)
    : base(context, unitOfWork)
    {
    }
        public async Task<List<Vaga>> GetVagasAsync(int idOng)
        {
            return  _context.Vagas.ToList().FindAll(x => x.IdOng == idOng);
        }
}