using Banco.Enums;
using Banco.Exceptions;

namespace Banco.Models.Entities
{
    public abstract class Usuario
    {
        private Guid Id { get; init; } = Guid.NewGuid();
        private string Nome {  get; set; }
        private string CPF { get; set; }
        private string Senha { get; set; }

        protected Usuario()
        {
            
        }

        protected Usuario(string cpf, string nome, string senha)
        {
            SetCpf(cpf);
            SetSenha(senha);
            Nome = nome;
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
    }
}
