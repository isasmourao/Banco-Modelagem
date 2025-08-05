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
        Cliente ObterPorCpf(string cpf);
        void Sacar(string cpf, Guid contaId, decimal valor);
        void Depositar(string cpf, Guid contaId, decimal valor);
        void Transferir(string cpfOrigem, Guid contaOrigemId, string cpfDestino, Guid contaDestinoId, decimal valor);
        decimal ConsultarSaldo(string cpf, Guid contaId);
        void SolicitarEmprestimo(string cpf, decimal valor);
        void CriarCliente(Cliente novoCliente);
    }
}
