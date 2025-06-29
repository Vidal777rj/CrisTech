using _2_Orientação_a_Objeto;

ContaBancaria conta01 = new ContaBancaria {Titular = "Michel Vidal",  Agencia="01", NumeroConta="100" };
ContaBancaria conta02 = new ContaBancaria {Titular = "Mikaella Oliveira",  Agencia = "01", NumeroConta = "101" };


conta01.Depositar(300);
conta01.MostrarDados();
conta02.Sacar(100);
conta02.Depositar(10, "Sobrecarga");
conta02.MostrarDados();

ContaPoupanca conta03 = new ContaPoupanca();
conta03.Depositar(500);
conta03.TaxaRendimento = 0.05;
conta03.AplicarRendimento();
conta03.MostrarDados();