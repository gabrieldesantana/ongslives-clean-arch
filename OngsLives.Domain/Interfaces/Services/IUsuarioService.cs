using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Domain.Interfaces.Services;

public interface IUsuarioService 
{
    Task<List<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(int id);
    Task<Usuario> GetByEmailAsync(string email);
    Task<Usuario> InsertAsync(InputUsuarioModel inputUsuarioModel);
    Task<Usuario> UpdateAsync(int id, EditUsuarioModel editUsuarioModel);
    Task<bool> UpdateSituationAsync(int id);
    Task<bool> DeleteAsync(int id);
}