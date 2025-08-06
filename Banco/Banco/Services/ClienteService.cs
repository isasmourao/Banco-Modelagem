using Banco.Infrastructure.Interfaces;
using Banco.Models.Entities;
using Banco.Services.Interfaces;

namespace Banco.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        private readonly IEmprestimoRepository _emprestimoRepo;
        private readonly IExtratoRepository _extratoRepo;

        public ClienteService(
            IClienteRepository repo,
            IEmprestimoRepository emprestimoRepo,
            IExtratoRepository extratoRepo)
        {
            _repo = repo;
            _emprestimoRepo = emprestimoRepo;
            _extratoRepo = extratoRepo;
        }


        public void CadastrarCliente(Cliente cliente)
        {
            if (_repo.ExisteCliente(cliente.CPF))
                throw new Exception("Cliente com esse CPF já existe.");

            _repo.Adicionar(cliente);
        }

        public void CriarCliente(Cliente novoCliente)
        {
            novoCliente.SetCpf(novoCliente.CPF);

            novoCliente.Contas = new List<Conta>
            {
                new Conta(novoCliente.CPF)
                {
                    Id = Guid.NewGuid(),
                    Numero = GerarNumeroConta(),
                    Saldo = 0
                }
            };

            _repo.Adicionar(novoCliente);
        }

        private string GerarNumeroConta()
        {
            return DateTime.Now.Ticks.ToString().Substring(10); // ou outro padrão
        }

        public void EditarSenha(string cpf, string novaSenha)
        {
            var cliente = _repo.ObterPorCpf(cpf);
            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            cliente.EditarSenha(novaSenha);
            _repo.Atualizar(cliente);
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

        public void Depositar(string cpf, Guid contaId, decimal valor)
        {
            var cliente = _repo.ObterPorCpf(cpf);
            var conta = cliente.Contas.FirstOrDefault(c => c.Id == contaId);
            if (conta == null)
                throw new Exception("Conta não encontrada.");

            cliente.Depositar(conta, valor);
            conta.AdicionarExtrato("Depósito", valor);
            _extratoRepo.Adicionar(new Extrato
            {
                ContaId = conta.Id,
                Data = DateTime.Now,
                Descricao = "Depósito",
                Valor = valor
            });

            _repo.Atualizar(cliente);
        }

        public void Sacar(string cpf, Guid contaId, decimal valor)
        {
            var cliente = _repo.ObterPorCpf(cpf);
            var conta = cliente.Contas.FirstOrDefault(c => c.Id == contaId);
            if (conta == null)
                throw new Exception("Conta não encontrada.");

            cliente.Sacar(conta, valor);
            conta.AdicionarExtrato("Saque", -valor);
            _extratoRepo.Adicionar(new Extrato
            {
                ContaId = conta.Id,
                Data = DateTime.Now,
                Descricao = "Saque",
                Valor = -valor
            });

            _repo.Atualizar(cliente);
        }

        public void Transferir(string cpfOrigem, Guid contaOrigemId, string cpfDestino, Guid contaDestinoId, decimal valor)
        {
            var clienteOrigem = _repo.ObterPorCpf(cpfOrigem);
            var clienteDestino = _repo.ObterPorCpf(cpfDestino);

            if (clienteOrigem == null || clienteDestino == null)
                throw new Exception("Cliente(s) não encontrado(s).");

            var contaOrigem = clienteOrigem.Contas.FirstOrDefault(c => c.Id == contaOrigemId);
            var contaDestino = clienteDestino.Contas.FirstOrDefault(c => c.Id == contaDestinoId);

            if (contaOrigem == null || contaDestino == null)
                throw new Exception("Conta(s) não encontrada(s).");

            clienteOrigem.Transferir(contaOrigem, contaDestino, valor);

            contaOrigem.AdicionarExtrato($"Transferência para {contaDestino.Numero}", -valor);
            contaDestino.AdicionarExtrato($"Transferência de {contaOrigem.Numero}", valor);

            _extratoRepo.Adicionar(new Extrato
            {
                ContaId = contaOrigem.Id,
                Data = DateTime.Now,
                Descricao = $"Transferência para {contaDestino.Numero}",
                Valor = -valor
            });

            _extratoRepo.Adicionar(new Extrato
            {
                ContaId = contaDestino.Id,
                Data = DateTime.Now,
                Descricao = $"Transferência de {contaOrigem.Numero}",
                Valor = valor
            });

            _repo.Atualizar(clienteOrigem);
            _repo.Atualizar(clienteDestino);
        }

        public void SolicitarEmprestimo(string cpf, decimal valor)
        {
            var cliente = _repo.ObterPorCpf(cpf);
            var emprestimo = new Emprestimo
            {
                CPFCliente = cliente.CPF,
                Valor = valor,
                DataSolicitacao = DateTime.Now,
                Aprovado = false
            };

            cliente.EmprestimosSolicitados.Add(emprestimo);
            _emprestimoRepo.Adicionar(emprestimo);
            _repo.Atualizar(cliente);
        }


        public decimal ConsultarSaldo(string cpf, Guid contaId)
        {
            var cliente = _repo.ObterPorCpf(cpf);
            var conta = cliente.Contas.FirstOrDefault(c => c.Id == contaId);
            if (conta == null)
                throw new Exception("Conta não encontrada.");

            return cliente.ConsultarSaldo(conta);
        }
        public Cliente ObterPorCpf(string cpf)
        {
            return _repo.ObterPorCpf(cpf);
        }

    }
}
