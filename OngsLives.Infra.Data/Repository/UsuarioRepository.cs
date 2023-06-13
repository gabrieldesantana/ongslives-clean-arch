using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;

public class UsuarioRepository : GenericRepository<Usuario>,  IUsuarioRepository
{
    public UsuarioRepository(OngLivesContext context, IUnitOfWork unitOfWork)
        : base (context, unitOfWork)
    {
    }
    public override async Task<List<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios
        .ToListAsync();
    }

    public async Task<Usuario> GetByEmailAsync(string email)
    {
        return await _context.Usuarios
        .FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
    }

}