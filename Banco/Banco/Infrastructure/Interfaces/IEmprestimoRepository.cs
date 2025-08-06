using Banco.Models.Entities;
using System.Collections.Generic;

namespace Banco.Infrastructure.Interfaces
{
    public interface IEmprestimoRepository
    {
        void Adicionar(Emprestimo emprestimo);
        List<Emprestimo> ListarTodos();
        List<Emprestimo> ListarPorCPF(string cpf);
        Emprestimo ObterPorId(Guid id);
        void Atualizar(Emprestimo emprestimo);
    }
}
