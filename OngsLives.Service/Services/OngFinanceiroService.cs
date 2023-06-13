using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Service.Validators;

namespace OngsLives.Service.Services;
public class OngFinanceiroService : IOngFinanceiroService
{
    private readonly IOngFinanceiroRepository _repository;
    private readonly OngFinanceiroValidator _validator;
    public OngFinanceiroService(IOngFinanceiroRepository repository, OngFinanceiroValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<List<OngFinanceiro>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<OngFinanceiro> GetByIdAsync(int id)
    {
        var ongFinanceiro = await _repository.GetByIdAsync(id);

        if (ongFinanceiro == null) return null;

        return ongFinanceiro;
    }

    public async Task<OngFinanceiro> UpdateAsync(int id, EditOngFinanceiroModel ongFinanceiroModel)
    {
        var ongFinanceiro = new OngFinanceiro
            (
            ongFinanceiroModel.IdOng,
            ongFinanceiroModel.Tipo,
            new DateTime(1999, 1, 1, 23, 59, 59),
            ongFinanceiroModel.Valor,
            ongFinanceiroModel.Origem
            );

        await _validator.ValidateAsync(ongFinanceiro);

        var ongFinanceiroEdit = await _repository.GetByIdAsync(id);

        if (ongFinanceiroEdit == null) return null;
        
        ongFinanceiroEdit.Id = id;
        ongFinanceiroEdit.IdOng = ongFinanceiro.IdOng;
        ongFinanceiroEdit.Tipo = ongFinanceiro.Tipo;
        ongFinanceiroEdit.Valor = ongFinanceiro.Valor;
        ongFinanceiroEdit.Origem = ongFinanceiro.Origem;

        ongFinanceiroEdit = await _repository.UpdateAsync(ongFinanceiroEdit);

        return ongFinanceiroEdit;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ongFinanceiro = await _repository.GetByIdAsync(id);

        if (ongFinanceiro == null) return false;
            
        await _repository.DeleteAsync(id);
        return true;
    }
}