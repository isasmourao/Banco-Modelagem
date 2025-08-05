using Banco.Infrastructure.Interfaces;
using Banco.Models.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ContaRepository : IContaRepository
{
    private static readonly string Caminho = "contas.json";
    private static List<Conta> contas = Carregar();

    public void Adicionar(Conta conta)
    {
        contas.Add(conta);
        Salvar();
    }

    public void Remover(Guid id)
    {
        var conta = contas.FirstOrDefault(c => c.Id == id);
        if (conta != null)
        {
            contas.Remove(conta);
            Salvar();
        }
    }

    public Conta ObterPorId(Guid id) =>
        contas.FirstOrDefault(c => c.Id == id);

    public List<Conta> ListarTodas() => contas;

    public void Atualizar(Conta conta)
    {
        var index = contas.FindIndex(c => c.Id == conta.Id);
        if (index >= 0)
        {
            contas[index] = conta;
            Salvar();
        }
    }

    private static void Salvar()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        File.WriteAllText(Caminho, JsonSerializer.Serialize(contas, options));
    }

    private static List<Conta> Carregar()
    {
        if (!File.Exists(Caminho))
            return new();
        var json = File.ReadAllText(Caminho);
        return JsonSerializer.Deserialize<List<Conta>>(json) ?? new();
    }
}
