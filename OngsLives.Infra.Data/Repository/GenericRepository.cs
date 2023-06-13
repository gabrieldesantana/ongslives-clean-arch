using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Persistence.Context;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;

namespace ONGLIVES.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly OngLivesContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly IUnitOfWork _unitOfWork;
        public GenericRepository(OngLivesContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return _dbSet
            .ToList()
            .FindAll(x => x.Actived == true);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity =  await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }
        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
            }
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = await GetByIdAsync(entity.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    await _unitOfWork.Commit();
                }
                catch (Exception)
                {
                    await _unitOfWork.Rollback();
                }
            }
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var retorno = await GetByIdAsync(id);

            if (retorno != null) 
            {
                try
                {
                    retorno.Actived = false;
                    await _unitOfWork.Commit();
                }
                catch (Exception)
                {

                    await _unitOfWork.Rollback();
                }
            }
        }

        public bool Exists(int id)
        {
            return _dbSet.Any(x => x.Id.Equals(id));
        }

        public async Task InsertPropAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
            }
        }
    }
}