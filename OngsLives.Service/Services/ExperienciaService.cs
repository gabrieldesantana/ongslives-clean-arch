using OngsLives.Domain.Entidades;
using OngsLives.Domain.Interfaces.Repository;
using OngsLives.Domain.Interfaces.Services;
using OngsLives.Domain.Models.EditModels;
using OngsLives.Domain.Models.InputModels;
using OngsLives.Service.Validators;

namespace OngsLives.Service.Services;

public class ExperienciaService : IExperienciaService
{
    private readonly IExperienciaRepository _repository;
    private readonly IVoluntarioRepository _voluntarioRepository;
    private readonly IOngRepository _ongRepository;
    private readonly ExperienciaValidator _validator;
    public ExperienciaService(IExperienciaRepository repository, IVoluntarioRepository voluntarioRepository, IOngRepository ongRepository, ExperienciaValidator validator)
    {
        _repository = repository;
        _voluntarioRepository = voluntarioRepository;
        _ongRepository = ongRepository;
        _validator = validator;
    }

    public async Task<List<Experiencia>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Experiencia> GetByIdAsync(int id)
    {
        var experiencia = await _repository.GetByIdAsync(id);

        if (experiencia == null) return null;

        return experiencia;
    }

    public async Task<Experiencia> InsertAsync(InputExperienciaModel inputExperienciaModel)
    {
        if (string.IsNullOrEmpty(inputExperienciaModel.NomeVoluntario))
        {
            throw new Exception("NomeVoluntario não informado");
        }
        
        if (string.IsNullOrEmpty(inputExperienciaModel.NomeOng))
        {
            throw new Exception("NomeOng não informado");
        }

        var voluntario = await _voluntarioRepository.GetByNomeAsync(inputExperienciaModel.NomeVoluntario);
        var ong = await _ongRepository.GetByNomeAsync(inputExperienciaModel.NomeOng);

        var experiencia = new Experiencia 
        (
        inputExperienciaModel.NomeVoluntario,
        inputExperienciaModel.NomeOng,
        inputExperienciaModel.ProjetoEnvolvido,
        inputExperienciaModel.Opiniao,
        inputExperienciaModel.Nota,
        inputExperienciaModel.DataExperienciaInicio,
        inputExperienciaModel.DataExperienciaFim
        );

        await _validator.ValidateAsync(experiencia);

        experiencia.IdOng = ong.Id;
        experiencia.IdVoluntario = voluntario.Id;

        await _repository.InsertAsync(experiencia);
        return experiencia;
    }

    public async Task<Experiencia> UpdateAsync(int id, EditExperienciaModel editExperienciaModel)
    {
        var experiencia = new Experiencia
            (
                "Edit model nomeVoluntario",
                "Edit model nomeOng",
                editExperienciaModel.ProjetoEnvolvido,
                editExperienciaModel.Opiniao,
                editExperienciaModel.Nota,
                new DateTime(2023, 01, 01),
                new DateTime(2023, 03, 01)
            );

        await _validator.ValidateAsync(experiencia);

        var experienciaEdit = await _repository.GetByIdAsync(id);

        if (experienciaEdit == null) return null;

        experienciaEdit.Id = id;
        experienciaEdit.ProjetoEnvolvido = editExperienciaModel.ProjetoEnvolvido;
        experienciaEdit.Opiniao = editExperienciaModel.Opiniao;
        experienciaEdit.Nota = editExperienciaModel.Nota;

        experienciaEdit = await _repository.UpdateAsync(experienciaEdit);

        return experienciaEdit;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        return true;
    }
}