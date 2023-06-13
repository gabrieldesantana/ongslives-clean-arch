using FluentValidation;
using OngsLives.Domain.Entidades;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;

namespace OngsLives.Domain.Interfaces.Services;

public interface IOngFinanceiroService
{
    Task<List<OngFinanceiro>> GetAllAsync();
    Task<OngFinanceiro> GetByIdAsync(int id);
    Task<OngFinanceiro> UpdateAsync(int id, EditOngFinanceiroModel editOngFinanceiroModel);
    Task<bool> DeleteAsync(int id);

}