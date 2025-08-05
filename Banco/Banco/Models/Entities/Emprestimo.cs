using Banco.Models.Entities;

public class Emprestimo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CPFCliente { get; set; }
    public decimal Valor { get; set; }
    public bool Aprovado { get; set; } = false;
    public DateTime DataSolicitacao { get; set; }
}
