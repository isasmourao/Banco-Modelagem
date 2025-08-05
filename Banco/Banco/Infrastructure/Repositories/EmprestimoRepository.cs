using Banco.Infrastructure.Interfaces;
using Banco.Models.Entities;
using System.Text.Json;

namespace Banco.Infrastructure.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly string _caminhoArquivo = "Data/emprestimos.json";

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

        private void Salvar(List<Emprestimo> emprestimos)
        {
            var json = JsonSerializer.Serialize(emprestimos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_caminhoArquivo, json);
        }
    }
}
