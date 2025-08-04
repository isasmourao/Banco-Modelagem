using Banco.Models.Entities;

namespace Banco.Services.Interfaces
{
    public interface IClienteService
    {
        void CadastrarCliente(Cliente cliente);
        void EditarSenha(string cpf, string novaSenha);
        void RemoverCliente(string cpf);
        List<Cliente> ListarTodos();
        bool ClienteExiste(string cpf);
    }
}
