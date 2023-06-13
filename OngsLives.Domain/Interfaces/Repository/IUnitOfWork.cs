namespace OngsLives.Domain.Interfaces.Repository;
public interface IUnitOfWork
{
    Task Commit();
    Task Rollback();
}