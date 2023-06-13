using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Domain.Interfaces.Services;

public interface IVoluntarioService 
{
    Task<List<Voluntario>> GetAllAsync();
    Task<Voluntario> GetByIdAsync(int id);
    Task<Voluntario> GetByEmailAsync(string email);
    Task<Voluntario> InsertAsync(InputVoluntarioModel inputVoluntarioModel);
    Task InsertImagemAsync(Voluntario voluntario);
    Task<Voluntario> UpdateAsync(int id, EditVoluntarioModel editVoluntarioModel);
    Task<bool> DeleteAsync(int id);

}