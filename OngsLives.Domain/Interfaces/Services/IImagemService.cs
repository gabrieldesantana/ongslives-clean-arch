using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Domain.Interfaces.Services;

public interface IImagemService
{
    Task<List<Imagem>> GetAllAsync();
    Task<Imagem> GetByIdAsync(int id);
    Task<Imagem> InsertAsync(InputImagemModel inputImagemModel);
    Task<Imagem> UpdateAsync(int id, EditImagemModel editImagemModel);
    Task<bool> DeleteAsync(int id);

}