using Banco.Exceptions;
using System.Text.RegularExpressions;

namespace Banco.Models.Entities
{
    public abstract class Usuario
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        public string Nome {  get; private set; }
        public string CPF { get; private set; }
        public string Senha { get; private set; }

        protected Usuario()
        {
            
        }

        protected Usuario(string cpf, string nome, string senha)
        {
            SetCpf(cpf);
            SetSenha(senha);
            Nome = nome;
        }

        public void SetCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                throw new DadoInseridoInvalidoException("O CPF não pode ser vazio.");

            var cpfSemFormatacao = Regex.Replace(cpf, "[^0-9]", "");
            if (cpfSemFormatacao.Length != 11)
                throw new DadoInseridoInvalidoException("O CPF digitado é inválido");

            CPF = cpfSemFormatacao;
        }

        public void SetSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
                throw new DadoInseridoInvalidoException("A senha digitada é inválida");

            Senha = senha;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void EditarSenha(string novaSenha)
        {
            SetSenha(novaSenha);
        }
    }
}
