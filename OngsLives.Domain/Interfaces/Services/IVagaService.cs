using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Domain.Interfaces.Services;
public interface IVagaService 
{
    Task<List<Vaga>> GetAllAsync();
    Task<Vaga> GetByIdAsync(int id);
    Task<Vaga> InsertAsync(InputVagaModel inputVagaModel);
    Task<Vaga> UpdateAsync(int id, EditVagaModel editVagaModel);
    Task<bool> DeleteAsync(int id);
}