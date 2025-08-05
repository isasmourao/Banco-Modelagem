using Banco.Models.Entities;

namespace Banco.Services.Interfaces
{
    public interface IContaService
    {
        void CriarConta(string cpf, string numero);
        void Depositar(Guid id, decimal valor);
        void Sacar(Guid id, decimal valor);
        List<Conta> Listar();
    }
}
