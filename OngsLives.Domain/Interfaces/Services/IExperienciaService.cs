using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Domain.Interfaces.Services;
public interface IExperienciaService
{
    Task<List<Experiencia>> GetAllAsync();
    Task<Experiencia> GetByIdAsync(int id);
    Task<Experiencia> InsertAsync(InputExperienciaModel inputExperienciaModel);
    Task<Experiencia> UpdateAsync(int id, EditExperienciaModel editExperienciaModel);
    Task<bool> DeleteAsync(int id);
}