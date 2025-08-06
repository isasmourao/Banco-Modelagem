using Banco.Enums;

namespace Banco.Services
{
    public class SessaoUsuarioService
    {
        public string CPF { get; private set; }
        public TipoUsuarioEnum? Tipo { get; private set; }
        public bool EstaLogado => !string.IsNullOrEmpty(CPF);

        public Action OnSessaoAlterada { get; set; }

        public void DefinirSessao(string cpf, TipoUsuarioEnum tipo)
        {
            CPF = cpf;
            Tipo = tipo;
            NotificarAlteracao();
        }

        public void Login(string cpf, TipoUsuarioEnum tipo)
        {
            DefinirSessao(cpf, tipo);
        }

        public void LimparSessao()
        {
            CPF = null;
            Tipo = null;
            NotificarAlteracao();
        }

        public void NotificarAlteracao()
        {
            OnSessaoAlterada?.Invoke();
        }

        public void StateHasChangedGlobal() => OnSessaoAlterada?.Invoke();
    }
}