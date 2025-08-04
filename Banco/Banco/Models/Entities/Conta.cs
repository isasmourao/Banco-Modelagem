namespace Banco.Models.Entities
{
    public class Conta
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string NumeroConta { get; set; }
        public decimal Saldo { get; set; } = 0;
        public List<Extrato> Extratos { get; set; } = new();

        public void AdicionarExtrato(string descricao, decimal valor)
        {
            Extratos.Add(new Extrato
            {
                Data = DateTime.Now,
                Descricao = descricao,
                Valor = valor
            });
        }
    }

}
