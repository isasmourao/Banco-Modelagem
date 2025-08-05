using Banco.Models.Entities;

namespace Banco.Infrastructure.Interfaces
{
    public interface IExtratoRepository
    {
        void Adicionar(Extrato extrato);
        List<Extrato> ListarTodos();
        List<Extrato> ListarPorConta(Guid contaId);
    }
}
