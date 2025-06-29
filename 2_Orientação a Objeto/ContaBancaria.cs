namespace _2_Orientação_a_Objeto
{
    class ContaBancaria
    {
        public string Titular { get; set; }
        public string? NumeroConta { get; set; }
        public string? Agencia { get; set; }
        public double Saldo { get; protected set; }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Console.WriteLine($"Valor de deposito realizado com sucesso: valor: {Saldo}");
        }
        public void Depositar(double valor, string msg)
        {
            Saldo += valor;
            Console.WriteLine($"Valor de deposito realizado com sucesso: valor: {Saldo} + {msg}");
        }
        public void Sacar(double valor) { 
            if(valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque realizado com sucesso: saldo atual {Saldo}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente");
            }
        }
        public  void MostrarDados()
        {
            Console.WriteLine("====================");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Numero conta: {NumeroConta}");
            Console.WriteLine($"Agência: {Agencia}");
            Console.WriteLine($"Saldo: {Saldo}");
            Console.WriteLine("====================");
        }

    }
}
