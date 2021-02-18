using System;

namespace DIOBank
{
  public class Conta
  {
    private TipoConta TipoConta { get; set; }
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }
    private string SenhaConta { get; set; }

    public Conta(){

    }

    public Conta(TipoConta tipoConta, double saldo, double credito, string nome, string senha)
    {
      this.Nome = nome;
      this.Saldo = saldo;
      this.Credito = credito;
      this.TipoConta = tipoConta;
      this.SenhaConta = senha;
    }

    public bool Sacar(double valorSaque)
    {
      if (this.Saldo - valorSaque < (this.Credito * -1))
      {
        Console.WriteLine("Saldo insuficiente");
        return false;
      }
      this.Saldo -= valorSaque;
      Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
      return true;
    }

    public void Depositar(double valorDeposito)
    {
      this.Saldo += valorDeposito;
      Console.WriteLine($"Saldo atual da conta de {this.Nome} é de {this.Saldo}");
    }

    public void Transferir(double valorTransferencia, Conta contaDeposito)
    {
      if (this.Sacar(valorTransferencia))
      {
        contaDeposito.Depositar(valorTransferencia);
      }
    }

    public bool ValidaAcesso( string senha)
    {
      if (!this.SenhaConta.Equals(senha))
        return false;
      return true;
    }

    //sobrescrevendo o método padrão de objetos ToString
    public override string ToString()
    {
      return $"TipoConta: {this.TipoConta} | Nome: {this.Nome} | Saldo: {this.Saldo} | Credito: {this.Credito}";

    }

    
  }

  
}