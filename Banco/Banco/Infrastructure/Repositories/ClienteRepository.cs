using Banco.Infrastructure.Interfaces;
using Banco.Models.Entities;
using System.Text.Json.Serialization;
using System.Text.Json;

public class ClienteRepository : IClienteRepository
{
    private static readonly string CaminhoArquivo = "clientes.json";
    private static List<Cliente> clientes = CarregarDoArquivo();

    public void Adicionar(Cliente cliente)
    {
        clientes.Add(cliente);
        SalvarNoArquivo();
    }

    public void Remover(string cpf)
    {
        var cliente = clientes.FirstOrDefault(c => c.CPF == cpf);
        if (cliente != null)
        {
            clientes.Remove(cliente);
            SalvarNoArquivo();
        }
    }

    public void Editar(string cpf, string novaSenha)
    {
        var cliente = clientes.FirstOrDefault(c => c.CPF == cpf);
        if (cliente != null)
        {
            cliente.EditarSenha(novaSenha);
            SalvarNoArquivo();
        }
    }

    public List<Cliente> ListarClientes()
    {
        return clientes;
    }

    public bool ExisteCliente(string cpf)
    {
        return clientes.Any(c => c.CPF == cpf);
    }

    public Cliente ObterPorCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf)) return null;

        string cpfNormalizado = cpf.Replace(".", "").Replace("-", "").Trim();

        return clientes.FirstOrDefault(c =>
            !string.IsNullOrWhiteSpace(c.CPF) &&
            c.CPF.Replace(".", "").Replace("-", "").Trim() == cpfNormalizado);
    }


    public void Atualizar(Cliente clienteAtualizado)
    {
        var index = clientes.FindIndex(c => c.CPF == clienteAtualizado.CPF);
        if (index >= 0)
        {
            clientes[index] = clienteAtualizado;
            SalvarNoArquivo();
        }
    }

    private static void SalvarNoArquivo()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        File.WriteAllText(CaminhoArquivo, JsonSerializer.Serialize(clientes, options));
    }

    private static List<Cliente> CarregarDoArquivo()
    {
        if (!File.Exists(CaminhoArquivo))
            return new List<Cliente>();

        var json = File.ReadAllText(CaminhoArquivo);
        return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
    }
}
