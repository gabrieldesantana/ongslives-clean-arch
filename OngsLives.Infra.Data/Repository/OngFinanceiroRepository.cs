using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;

public class OngFinanceiroRepository : GenericRepository<OngFinanceiro>, IOngFinanceiroRepository
{
    public OngFinanceiroRepository(OngLivesContext context, IUnitOfWork unitOfWork) 
    : base(context, unitOfWork)
    {
    }
 
}