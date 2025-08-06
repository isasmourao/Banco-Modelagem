using Banco.Models.Entities;

public class Emprestimo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CPFCliente { get; set; }
    public decimal Valor { get; set; }
    public bool? Aprovado { get; set; }  // true = aprovado, false = recusado, null = pendente
    public DateTime DataSolicitacao { get; set; }
}
