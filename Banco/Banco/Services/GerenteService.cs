using Banco.Models.Entities;
using Banco.Services.Interfaces;
using Banco.Infrastructure.Interfaces;

namespace Banco.Services
{
    public class GerenteService : IGerenteService
    {
        private readonly IGerenteRepository _gerenteRepo;
        private readonly IEmprestimoRepository _emprestimoRepo;

        public GerenteService(IGerenteRepository gerenteRepo, IEmprestimoRepository emprestimoRepo)
        {
            _gerenteRepo = gerenteRepo;
            _emprestimoRepo = emprestimoRepo;
        }

        public bool GerenteExiste(string cpf)
        {
            return _gerenteRepo.ExisteGerente(cpf);
        }

        public Gerente ObterPorCpf(string cpf)
        {
            return _gerenteRepo.ObterPorCpf(cpf);
        }

        public List<Emprestimo> ListarEmprestimosPendentes()
        {
            return _emprestimoRepo.ListarTodos().Where(e => !e.Aprovado.HasValue).ToList();
        }

        public void AprovarEmprestimo(string cpfGerente, Guid emprestimoId)
        {
            var gerente = ObterPorCpf(cpfGerente) ?? throw new Exception("Gerente não encontrado.");
            var emprestimo = _emprestimoRepo.ObterPorId(emprestimoId);
            gerente.AprovarEmprestimo(emprestimo);
            _emprestimoRepo.Atualizar(emprestimo);
        }

        public void RecusarEmprestimo(string cpfGerente, Guid emprestimoId)
        {
            var gerente = ObterPorCpf(cpfGerente) ?? throw new Exception("Gerente não encontrado.");
            var emprestimo = _emprestimoRepo.ObterPorId(emprestimoId);
            gerente.RecusarEmprestimo(emprestimo);
            _emprestimoRepo.Atualizar(emprestimo);
        }
    }
}
