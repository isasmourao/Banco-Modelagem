namespace Banco.Models.Entities
{
    public class Conta
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Numero { get; set; }

        public decimal Saldo { get; set; } = 0;

        public string CPFCliente { get; set; }

        public List<Extrato> Extratos { get; set; } = new();

        public Conta() { }

        public Conta(string cpfCliente)
        {
            CPFCliente = cpfCliente;
        }

        public void AdicionarExtrato(string descricao, decimal valor)
        {
            Extratos.Add(new Extrato
            {
                Data = DateTime.Now,
                Descricao = descricao,
                Valor = valor
            });
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("Valor inválido para depósito.");

            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0 || valor > Saldo)
                throw new Exception("Saldo insuficiente ou valor inválido.");

            Saldo -= valor;
        }

        public void Transferir(Conta destino, decimal valor)
        {
            Sacar(valor);
            destino.Depositar(valor);
        }
    }
}
