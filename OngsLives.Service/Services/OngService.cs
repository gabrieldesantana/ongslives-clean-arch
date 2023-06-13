using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;
using OngsLives.Service.Validators;
using System.ComponentModel.DataAnnotations;

namespace OngsLives.Service.Services;

public class OngService : IOngService
{
    private readonly IOngRepository _repository;
    private readonly IVagaRepository _vagaRepository;
    private readonly OngValidator _validator;
    public OngService(IOngRepository repository, IVagaRepository vagaRepository, OngValidator validator)
    {
        _repository = repository;
        _vagaRepository = vagaRepository;
        _validator = validator;
    }

    public async Task<List<Ong>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Ong> GetByIdAsync(int id)
    {
        var ong = await _repository.GetByIdAsync(id);

        var vagas = await _vagaRepository.GetVagasAsync(ong.Id);

        //Adiciona vagas a ong
        ong.Vagas = vagas;

        if (ong == null) return null;

        return ong;
    }

    public async Task<Ong> GetByEmailAsync(string email)
    {
        var ong = await _repository.GetByEmailAsync(email);

        var vagas = await _vagaRepository.GetVagasAsync(ong.Id);

        ong.Vagas = vagas;

        if (ong == null) return null;

        return ong;
    }

    public async Task<Ong> InsertAsync(InputOngModel inputOngModel)
    {
        var ong = new Ong 
        (
        inputOngModel.Nome,
        inputOngModel.CNPJ,
        inputOngModel.Telefone,
        inputOngModel.Email,
        inputOngModel.AreaAtuacao,
        inputOngModel.QuantidadeEmpregados,
        inputOngModel.Endereco
        );

        await _validator.ValidateAsync(ong);

        await _repository.InsertAsync(ong);
        return ong;
    }
    
    public async Task InsertVagaAsync(Ong ong)
    {
        await _repository.InsertPropAsync(ong);
    }

    public async Task InsertFinanceiroAsync(Ong ong)
    {
        await _repository.InsertPropAsync(ong);
    }

    public async Task InsertImagemAsync(Ong ong)
    {
        await _repository.InsertPropAsync(ong);
    }



    public async Task<Ong> UpdateAsync(int id, EditOngModel editOngModel)
    {
        var ong = new Ong
            (
            "Edit model Nome",
            "Edit model CNPJ",
            editOngModel.Telefone,
            editOngModel.Email,
            "Edit model areaAtuacao",
            editOngModel.QuantidadeEmpregados,
            editOngModel.Endereco
            );

        await _validator.ValidateAsync(ong);

        var ongEdit = await _repository.GetByIdAsync(editOngModel.Id);

        if (ongEdit == null) return null;

        ongEdit.Id = editOngModel.Id;
        ongEdit.Telefone = editOngModel.Telefone;
        ongEdit.Email = editOngModel.Email;
        ongEdit.QuantidadeEmpregados = editOngModel.QuantidadeEmpregados;
        ongEdit.Endereco = editOngModel.Endereco;

        ongEdit = await _repository.UpdateAsync(ongEdit);

        return ongEdit;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var voluntario = await _repository.GetByIdAsync(id);

        if (voluntario == null) return false;
            
        await _repository.DeleteAsync(id);
        return true;
    }
}