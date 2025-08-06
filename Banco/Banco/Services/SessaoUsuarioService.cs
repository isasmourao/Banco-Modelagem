using Banco.Enums;

namespace Banco.Services
{
    public class SessaoUsuarioService
    {
        public string CPF { get; private set; }
        public TipoUsuarioEnum Tipo { get; private set; }
        public bool EstaLogado { get; private set; } = false;
        public void DefinirSessao(string cpf, TipoUsuarioEnum tipo)
        {
            CPF = cpf;
            Tipo = tipo;
        }

        public void LimparSessao()
        {
            CPF = null;
            Tipo = TipoUsuarioEnum.Nenhum;
        }

        public void Login(string cpf, TipoUsuarioEnum tipo)
        {
            CPF = cpf;
            Tipo = tipo;
            EstaLogado = true;
        }
    }
}