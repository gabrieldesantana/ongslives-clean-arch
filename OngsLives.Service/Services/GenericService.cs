using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;
using OngsLives.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngsLives.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _genericRepository;
        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<List<T>> GetAllAsync() => await _genericRepository.GetAllAsync();

        public async Task<T> GetByIdAsync(int id) => await _genericRepository.GetByIdAsync(id);

        public async Task<T> InsertAsync<TFluentValidator>(T entity) where TFluentValidator : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<TFluentValidator>());

            _genericRepository.InsertAsync(entity);

            return entity;
        }

        public async Task InsertPropAsync<TFluentValidator>(T entity) where TFluentValidator : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<AbstractValidator<T>>());
            _genericRepository.InsertPropAsync(entity);
        }

        public async Task<T> UpdateAsync<TFluentValidator>(T entity) where TFluentValidator : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<TFluentValidator>());
            _genericRepository.UpdateAsync(entity);
            return entity;
        }
        public async Task DeleteAsync(int id) => _genericRepository.DeleteAsync(id);

        private void Validate(T entity, AbstractValidator<T> validator)
        {
            if (entity == null)
                throw new Exception("Registros não detectados");

            validator.ValidateAndThrow(entity);
        }
    }
}
