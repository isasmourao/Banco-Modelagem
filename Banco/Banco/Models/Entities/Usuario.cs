using Banco.Enums;
using Banco.Exceptions;

namespace Banco.Models.Entities
{
    public class Usuario
    {
        private Guid Id { get; init; }
        private string Nome {  get; set; }
        private string CPF { get; set; }
        private string Senha { get; set; }
        private decimal ValorEmConta { get; set; }
        private TipoUsuarioEnum Tipo { get; set; }
        private List<Extrato> ListaExtratos { get; set; }

        public Usuario(string cpf, string nome, string senha, TipoUsuarioEnum tipoUsuario, decimal valorConta, List<Extrato> listaExtratos)
        {
            SetCpf(cpf);
            SetSenha(senha);
            SetValorConta(valorConta);
            Tipo = tipoUsuario;
            Nome = nome;
            ListaExtratos = listaExtratos;
            Id = new Guid();
        }

        private void SetCpf(string cpf)
        {
            cpf = cpf.Replace("[^0-9]", "");

            if (cpf.Length != 11)
                throw new DadoInseridoInvalidoException("O CPF digitado é inválido");

            CPF = cpf;
        }

        private void SetSenha(string senha)
        {
            if (senha.Length < 6)
                throw new DadoInseridoInvalidoException("A senha digitada é inválida");

            Senha = senha;
        }

        private void SetValorConta(decimal valor)
        {
            if (valor < 0)
                throw new DadoInseridoInvalidoException("O valor digitado é inválido");

            ValorEmConta = valor;
        }
    }
}
