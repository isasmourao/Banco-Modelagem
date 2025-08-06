namespace Banco.Models.Entities
{
    public class Gerente : Usuario
    {
        public List<Cliente> ClientesGerenciados { get; set; } = new();

        public void AprovarEmprestimo(Emprestimo emprestimo)
        {
            if (emprestimo == null) throw new Exception("Empréstimo inválido.");
            emprestimo.Aprovado = true;
        }

        public void RecusarEmprestimo(Emprestimo emprestimo)
        {
            if (emprestimo == null) throw new Exception("Empréstimo inválido.");
            emprestimo.Aprovado = false;
        }

        public List<Cliente> VerTodosClientes() => ClientesGerenciados;
    }
}
