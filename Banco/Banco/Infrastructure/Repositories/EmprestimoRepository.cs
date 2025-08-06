using Banco.Infrastructure.Interfaces;
using Banco.Models.Entities;
using System.Text.Json;

namespace Banco.Infrastructure.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly string _caminhoArquivo = "emprestimos.json";

        public void Adicionar(Emprestimo emprestimo)
        {
            var emprestimos = ListarTodos();
            emprestimos.Add(emprestimo);
            Salvar(emprestimos);
        }

        public List<Emprestimo> ListarTodos()
        {
            if (!File.Exists(_caminhoArquivo))
                return new List<Emprestimo>();

            var json = File.ReadAllText(_caminhoArquivo);
            return JsonSerializer.Deserialize<List<Emprestimo>>(json) ?? new List<Emprestimo>();
        }

        public List<Emprestimo> ListarPorCPF(string cpf)
        {
            return ListarTodos().Where(e => e.CPFCliente == cpf).ToList();
        }

        public Emprestimo ObterPorId(Guid id)
        {
            return ListarTodos().FirstOrDefault(e => e.Id == id);
        }

        public void Atualizar(Emprestimo emprestimoAtualizado)
        {
            var emprestimos = ListarTodos();
            var index = emprestimos.FindIndex(e => e.Id == emprestimoAtualizado.Id);

            if (index == -1)
                throw new Exception("Empréstimo não encontrado para atualização.");

            emprestimos[index] = emprestimoAtualizado;
            Salvar(emprestimos);
        }

        private void Salvar(List<Emprestimo> emprestimos)
        {
            var json = JsonSerializer.Serialize(emprestimos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_caminhoArquivo, json);
        }
    }
}
