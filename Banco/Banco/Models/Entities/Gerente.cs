namespace Banco.Models.Entities
{
    public class Gerente : Usuario
    {
        public List<Cliente> ClientesGerenciados { get; set; } = new();

        public void AprovarEmprestimo(Emprestimo emprestimo) 
        {

        }

        public void RecusarEmprestimo(Emprestimo emprestimo) 
        {
        
        }

        public List<Cliente> VerTodosClientes() => ClientesGerenciados;
    }
}
