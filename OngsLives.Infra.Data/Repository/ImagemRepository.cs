using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;

public class ImagemRepository : GenericRepository<Imagem>, IImagemRepository
{
    public ImagemRepository(OngLivesContext context, IUnitOfWork unitOfWork)
    : base(context, unitOfWork)
    {
    }
}