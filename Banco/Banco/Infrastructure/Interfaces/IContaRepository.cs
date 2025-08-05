using Banco.Models.Entities;

namespace Banco.Infrastructure.Interfaces
{
    public interface IContaRepository
    {
        void Adicionar(Conta conta);
        void Remover(Guid id);
        Conta ObterPorId(Guid id);
        List<Conta> ListarTodas();
        void Atualizar(Conta conta);
    }
}
