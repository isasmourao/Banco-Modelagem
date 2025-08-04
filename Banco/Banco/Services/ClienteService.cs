using Banco.Infrastructure.Interfaces;
using Banco.Models.Entities;
using Banco.Services.Interfaces;

namespace Banco.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public void CadastrarCliente(Cliente cliente)
        {
            if (_repo.ExisteCliente(cliente.CPF))
                throw new Exception("Cliente com esse CPF já existe.");

            _repo.Adicionar(cliente);
        }

        public void EditarSenha(string cpf, string novaSenha)
        {
            if (!_repo.ExisteCliente(cpf))
                throw new Exception("Cliente não encontrado.");

            _repo.Editar(cpf, novaSenha);
        }

        public void RemoverCliente(string cpf)
        {
            if (!_repo.ExisteCliente(cpf))
                throw new Exception("Cliente não encontrado.");

            _repo.Remover(cpf);
        }

        public List<Cliente> ListarTodos()
        {
            return _repo.ListarClientes();
        }

        public bool ClienteExiste(string cpf)
        {
            return _repo.ExisteCliente(cpf);
        }
    }
}
