using FluentValidation;
using OngsLives.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngsLives.Domain.Interfaces.Services
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> InsertAsync<TFluentValidator>(T entity) where TFluentValidator : AbstractValidator<T>;
        Task InsertPropAsync<TFluentValidator>(T entity) where TFluentValidator : AbstractValidator<T>;
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync<TFluentValidator>(T entity) where TFluentValidator : AbstractValidator<T>;
        Task DeleteAsync(int id);
    }
}
