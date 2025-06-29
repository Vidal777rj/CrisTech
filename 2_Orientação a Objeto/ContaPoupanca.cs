
namespace _2_Orientação_a_Objeto
{
    class ContaPoupanca : ContaBancaria
    {
        public double TaxaRendimento { get; set; }
        public void AplicarRendimento()
        {
            double rendimento = Saldo * TaxaRendimento;
            Saldo += rendimento;
            Console.WriteLine($"Rendimento atual: {Saldo}");
        }

        public void MostrarDados()
        {
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Numero conta: {NumeroConta}");
            Console.WriteLine($"{Saldo} com rendimentos");
        }
    }
}
