using Banco.Models.Entities;

namespace Banco.Services.Interfaces
{
    public interface IGerenteService
    {
        bool GerenteExiste(string cpf);
        Gerente ObterPorCpf(string cpf);
        List<Emprestimo> ListarEmprestimosPendentes();
        void AprovarEmprestimo(string cpfGerente, Guid emprestimoId);
        void RecusarEmprestimo(string cpfGerente, Guid emprestimoId);
    }
}
