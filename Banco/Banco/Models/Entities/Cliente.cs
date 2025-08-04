namespace Banco.Models.Entities
{
    public class Cliente : Usuario
    {
        public List<Conta> Contas { get; set; } = new List<Conta>();
        public List<Emprestimo> EmprestimosSolicitados { get; set; } = new();

        public void SolicitarEmprestimo(decimal valor) 
        { 
        
        }

        public void Transferir(Conta origem, Conta destino, decimal valor) 
        {
        
        }

        public void Sacar(Conta conta, decimal valor) 
        {
        
        }

        public void Depositar(Conta conta, decimal valor) 
        {
        
        }

        public decimal ConsultarSaldo(Conta conta) => conta.Saldo;
    }

}
