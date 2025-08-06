using Banco.Infrastructure.Interfaces;
using Banco.Models.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Banco.Infrastructure.Repositories
{
    public class GerenteRepository : IGerenteRepository
    {
        private readonly string _caminhoArquivo = "gerentes.json";

        public bool ExisteGerente(string cpf)
        {
            var gerentes = CarregarGerentes();
            return gerentes.Any(g => g.CPF == cpf);
        }

        public Gerente ObterPorCpf(string cpf)
        {
            var gerentes = CarregarGerentes();
            return gerentes.FirstOrDefault(g => g.CPF == cpf);
        }

        private List<Gerente> CarregarGerentes()
        {
            if (!File.Exists(_caminhoArquivo))
                return new List<Gerente>();

            var json = File.ReadAllText(_caminhoArquivo);
            return JsonSerializer.Deserialize<List<Gerente>>(json) ?? new List<Gerente>();
        }
    }
}
