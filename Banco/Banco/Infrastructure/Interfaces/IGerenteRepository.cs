using Banco.Models.Entities;

namespace Banco.Infrastructure.Interfaces
{
    public interface IGerenteRepository
    {
        bool ExisteGerente(string cpf);
        Gerente ObterPorCpf(string cpf);
    }
}