using Banco.Infrastructure.Interfaces;
using Banco.Models.Entities;
using System.Text.Json;

namespace Banco.Infrastructure.Repositories
{
    public class ExtratoRepository : IExtratoRepository
    {
        private static readonly string _caminhoArquivo = "extratos.json";

        public void Adicionar(Extrato extrato)
        {
            var extratos = ListarTodos();
            extratos.Add(extrato);
            Salvar(extratos);
        }

        public List<Extrato> ListarTodos()
        {
            if (!File.Exists(_caminhoArquivo))
                return new List<Extrato>();

            var json = File.ReadAllText(_caminhoArquivo);
            return JsonSerializer.Deserialize<List<Extrato>>(json) ?? new List<Extrato>();
        }

        public List<Extrato> ListarPorContaId(Guid contaId)
        {
            return ListarTodos().Where(e => e.ContaId == contaId).ToList();
        }

        private void Salvar(List<Extrato> extratos)
        {
            var json = JsonSerializer.Serialize(extratos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_caminhoArquivo, json);
        }
    }
}
