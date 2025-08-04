namespace Banco.Models.Entities
{
    public class Emprestimo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Cliente Solicitante { get; set; }
        public decimal Valor { get; set; }
        public bool Aprovado { get; set; } = false;
    }

}
