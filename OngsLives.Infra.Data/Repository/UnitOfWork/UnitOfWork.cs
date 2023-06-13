using ONGLIVES.API.Persistence.Context;
using OngsLives.Domain.Interfaces.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly OngLivesContext _context;

    public UnitOfWork(OngLivesContext context)
    {
        _context = context;
    }
    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
    public async Task Rollback()
    {
        await _context.DisposeAsync();
    }
}