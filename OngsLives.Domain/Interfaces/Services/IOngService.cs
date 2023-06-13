using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Domain.Interfaces.Services;

public interface IOngService
{
    Task<List<Ong>> GetAllAsync();
    Task<Ong> GetByIdAsync(int id);
    Task<Ong> GetByEmailAsync(string email);
    Task<Ong> InsertAsync(InputOngModel inputOngModel);

    Task InsertVagaAsync(Ong ong);
    Task InsertFinanceiroAsync(Ong ong);
    Task InsertImagemAsync(Ong ong);

    Task<Ong> UpdateAsync(int id, EditOngModel editOngModel);
    Task<bool> DeleteAsync(int id);


}