using Banco.Models.Entities;

namespace Banco.Infrastructure.Interfaces
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        void Remover(string cpf);
        void Editar(string cpf, string novaSenha);
        List<Cliente> ListarClientes();
        bool ExisteCliente(string cpf);
    }
}
