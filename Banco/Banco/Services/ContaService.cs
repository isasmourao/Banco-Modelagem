using Banco.Models.Entities;
using Banco.Infrastructure.Interfaces;
using Banco.Services.Interfaces;

namespace Banco.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repo;

        public ContaService(IContaRepository repo)
        {
            _repo = repo;
        }

        public void CriarConta(string cpf, string numero)
        {
            var conta = new Conta { CPFCliente = cpf, Numero = numero };
            _repo.Adicionar(conta);
        }

        public void Depositar(Guid id, decimal valor)
        {
            var conta = _repo.ObterPorId(id) ?? throw new Exception("Conta não encontrada");
            conta.Depositar(valor);
            _repo.Atualizar(conta);
        }

        public void Sacar(Guid id, decimal valor)
        {
            var conta = _repo.ObterPorId(id) ?? throw new Exception("Conta não encontrada");
            conta.Sacar(valor);
            _repo.Atualizar(conta);
        }

        public List<Conta> Listar() => _repo.ListarTodas();
    }
}
