using System;
using System.Collections.Generic;

namespace DIOBank
{
  class Program
  {
    static List<Conta> listaContas = new List<Conta>();
    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirConta();
            break;
          case "3":
            Transferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
            Depositar();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOcaoUsuario();
      }
      Console.WriteLine("Obrigado por utilizar nossos Serviços.");
      Console.ReadLine();
    }
    private static void ListarContas()
    {
      Console.WriteLine("Listas de Contas");

      int index = 0;
      foreach (Conta conta in listaContas)
      {
        Console.WriteLine($"#{index + 1} - {conta}");
        index++;
      }

      if (index == 0)
        Console.WriteLine("Não existe contas cadastradas.");

    }

    private static string ObterOcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Dio Bank ao seu dispor!!");
      Console.WriteLine("Informe a opção desejada:");
      Console.WriteLine("1 - Listar Contas");
      Console.WriteLine("2 - Inserir nova Cont");
      Console.WriteLine("3 - Transferir");
      Console.WriteLine("4 - Sacar");
      Console.WriteLine("c - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }

    private static void InserirConta()
    {
      Console.WriteLine("Inserir nova conta");
      Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica: ");
      int entradaTipoConta = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o Nome do Cliente: ");
      string entradaNomeCliente = Console.ReadLine();

      Console.WriteLine("Digite o Saldo Inicial: ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.WriteLine("Digite o crédito: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Console.WriteLine("Digite a senha da Conta: ");
      string senha = Console.ReadLine().ToUpper();

      listaContas.Add(new Conta(
          tipoConta: (TipoConta)entradaTipoConta,
          saldo: entradaSaldo,
          credito: entradaCredito,
          nome: entradaNomeCliente,
          senha: senha
      ));
    }
    private static void Sacar()
    {
      Console.Write("Digite o número da conta: ");
      int NumeroConta = int.Parse(Console.ReadLine()) - 1;
      Conta contaAtual = listaContas[NumeroConta];

        if(!ValidaSenha(contaAtual))
        {
            Console.WriteLine("Acesso negado, operação não realizada!");
            return;   
        }
    
      Console.Write("Digite o valor a ser sacado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      contaAtual.Sacar(valorSaque);
    }

    private static void Depositar()
    {
      Console.Write("Digite o número da conta: ");
      int NumeroConta = int.Parse(Console.ReadLine()) - 1;
      Conta contaAtual = listaContas[NumeroConta];

      Console.Write("Digite o valor a ser depositado: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      contaAtual.Sacar(valorDeposito);
    }
    private static void Transferir()
    {
       Console.Write("Digite o número da conta Origem: ");
      int NumeroContaOrigem = int.Parse(Console.ReadLine()) - 1;
        Conta contaOrigem = listaContas[NumeroContaOrigem];

       Console.Write("Digite o número da conta Destino: ");
      int NumeroContaDestino = int.Parse(Console.ReadLine()) - 1;

       Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      if(!ValidaSenha(contaOrigem))
        {
            Console.WriteLine("Acesso negado, operação não realizada!");
            return;   
        }

      listaContas[NumeroContaOrigem].Transferir(valorTransferencia, listaContas[NumeroContaDestino]);
    }

    private static bool ValidaSenha(Conta conta){
      Console.Write("Digite a senha da Conta: ");
      string senhaEntrada = Console.ReadLine().ToUpper();
      return conta.ValidaAcesso(senhaEntrada);
    }
  }
}
