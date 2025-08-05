namespace Banco.Models.Entities
{
    public class Extrato
    {
        public Guid ContaId { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
