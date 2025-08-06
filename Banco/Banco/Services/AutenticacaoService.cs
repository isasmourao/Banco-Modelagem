using Banco.Enums;
using Banco.Infrastructure.Interfaces;

public class AutenticacaoService
{
    private readonly IClienteRepository _clienteRepo;
    private readonly IGerenteRepository _gerenteRepo;

    public AutenticacaoService(IClienteRepository clienteRepo, IGerenteRepository gerenteRepo)
    {
        _clienteRepo = clienteRepo;
        _gerenteRepo = gerenteRepo;
    }

    public (TipoUsuarioEnum tipo, object usuario) Autenticar(string cpf, string senha)
    {
        var cliente = _clienteRepo.ObterPorCpf(cpf);
        if (cliente != null && cliente.Senha == senha)
            return (TipoUsuarioEnum.Cliente, cliente);

        var gerente = _gerenteRepo.ObterPorCpf(cpf);
        if (gerente != null && gerente.Senha == senha)
            return (TipoUsuarioEnum.Gerente, gerente);

        return (TipoUsuarioEnum.Nenhum, null);
    }
}
