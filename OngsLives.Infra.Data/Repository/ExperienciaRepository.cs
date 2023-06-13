using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;

public class ExperienciaRepository : GenericRepository<Experiencia>, IExperienciaRepository
{
    public ExperienciaRepository(OngLivesContext context, IUnitOfWork unitOfWork) 
    : base(context, unitOfWork)
    {
        
    }
}