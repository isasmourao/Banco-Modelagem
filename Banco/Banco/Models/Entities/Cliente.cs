using System;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Models.Entities
{
    public class Cliente : Usuario
    {
        public List<Conta> Contas { get; set; } = new List<Conta>();
        public List<Emprestimo> EmprestimosSolicitados { get; set; } = new();

        public void SolicitarEmprestimo(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("Valor inválido para empréstimo.");

            EmprestimosSolicitados.Add(new Emprestimo
            {
                Valor = valor,
                DataSolicitacao = DateTime.Now,
                Aprovado = false
            });
        }

        public void Transferir(Conta origem, Conta destino, decimal valor)
        {
            if (!Contas.Contains(origem))
                throw new Exception("Conta de origem não pertence ao cliente.");

            origem.Transferir(destino, valor);
        }

        public void Sacar(Conta conta, decimal valor)
        {
            if (!Contas.Contains(conta))
                throw new Exception("Conta não pertence ao cliente.");

            conta.Sacar(valor);
        }

        public void Depositar(Conta conta, decimal valor)
        {
            if (!Contas.Contains(conta))
                throw new Exception("Conta não pertence ao cliente.");

            conta.Depositar(valor);
        }

        public decimal ConsultarSaldo(Conta conta)
        {
            if (!Contas.Contains(conta))
                throw new Exception("Conta não pertence ao cliente.");

            return conta.Saldo;
        }
    }
}
