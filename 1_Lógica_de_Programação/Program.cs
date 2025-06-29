/*
dizerNome("Michel", "Vidal");
static void dizerNome(params string[] nomes)
{
    foreach (string nome in nomes)
    {
        System.Console.WriteLine(nome);
    }
}


string idade;
idade = "Trinta";
System.Console.WriteLine(idade);
double pi;
pi = Math.PI;
System.Console.WriteLine(pi.ToString("F3"));

//conversão
int a = 100;
bool b = Convert.ToBoolean(a);
System.Console.WriteLine(b.GetType());

System.Console.Write("Digite seu nome: ");
string nome = Console.ReadLine();

System.Console.Write("Digite sua idade: ");
int idade = Convert.ToInt16(Console.ReadLine());

System.Console.WriteLine($"Bem vindo {nome}");
System.Console.WriteLine($"Idade: {idade}");

// Incrememnto, Decremento
int numero = 10;
int numero2 = 5;
numero++;
numero2--;
System.Console.WriteLine(numero);
System.Console.WriteLine(numero2);

double resultadoRaiz = Math.Sqrt(3);
System.Console.WriteLine(resultadoRaiz);

List<int> randomInts = new List<int> { 1, 10, 55, 80, 45, 888, 542, 982, 5555, 4545, 4 };
randomInts.Sort();

foreach (int randomInt in randomInts)
{
    System.Console.WriteLine(randomInt);
}

//Divisão
System.Console.Write("Digite o primeiro número: ");
double n1 = Convert.ToDouble(Console.ReadLine());
System.Console.Write("Digite o segundo número: ");
double n2 = Convert.ToDouble(Console.ReadLine());

double resultadoDaDivisao = n1 / n2;
System.Console.WriteLine(resultadoDaDivisao);

System.Console.WriteLine(calcularDivisao(40,2));
static double calcularDivisao(double n1, double n2)
{
    return n1 / n2;
}


//if else switch
System.Console.Write("Digite sua idade: ");
uint idade = Convert.ToUInt16(Console.ReadLine());

if (idade < 18)
{
    System.Console.WriteLine($"Menor de idade, não pode tirar habilitação");
}
else if (idade > 80)
{
    System.Console.WriteLine($"{idade}: Uma pessoa idosa");
}
else
{
    System.Console.WriteLine("Meia idade");
}

bool status = true;
if (status == false)
{
    System.Console.WriteLine("Loja fechada!");
}
else
{
    System.Console.WriteLine("Loja aberta!");
}


DateTime diaDaSemana = DateTime.Now;
DayOfWeek diaExato = diaDaSemana.DayOfWeek;
switch (diaExato)
{
    case DayOfWeek.Monday:
        System.Console.WriteLine("Segunda");
        break;
    case DayOfWeek.Tuesday:
        System.Console.WriteLine("Terça");
        break;
    case DayOfWeek.Wednesday:
        System.Console.WriteLine("Quarta");
        break;
    case DayOfWeek.Thursday:
        System.Console.WriteLine("Quinta");
        break;
    case DayOfWeek.Friday:
        System.Console.WriteLine("Sexta");
        break;
    case DayOfWeek.Saturday:
        System.Console.WriteLine("Sabado");
        break;
    case DayOfWeek.Sunday:
        System.Console.WriteLine("Domingo");
        break;
}


//operador ternario
Console.Write("Você é administrador?  ");
bool adm = Convert.ToBoolean(Console.ReadLine());
Console.Write("Você é do setor operacional?  ");
bool op = Convert.ToBoolean(Console.ReadLine());
if (!adm || !op)
{
    System.Console.WriteLine("Login com restrições");
}
else
{
    System.Console.WriteLine("Acesso liberado!");
}

//for
for (int i = 1000; i >= 1; i--)
{
System.Console.WriteLine("Loop: " + i);
}


//ARRAY
int[] numero = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
for (int i = 0; i < numero.Length; i++)
{
    System.Console.WriteLine(numero[i]);
}
var n = numero.Where(p => p == 3).ToList();
System.Console.WriteLine(n[0]);

//METODOS
parabens("Feliz Aniversario");
static void parabens(string mensagem)
{
    for (int m = 1; m < 10; m++)
    {
        System.Console.WriteLine($"{m} - {mensagem}");
    }
}
System.Console.WriteLine(mult(10, 3));
static double mult(double n1, double n2)
{
    return n1 * n2;
}

System.Console.WriteLine(soma(2, 5, 8));;
static double soma(params int[] n)
{
    int total = 0;
    foreach (int p in n)
    {
        total += p;
    }
    return total; ;
}

int n1;
int n2;
int resultado;
//TryCatch
try
{
    Console.Write("Digite o primeiro valor: ");
    n1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Digite o segundo valor: ");
    n2 = Convert.ToInt32(Console.ReadLine());
    resultado = n1 / n2;
    System.Console.WriteLine($"{n1} / {n2} = {resultado}");
}
catch (DivideByZeroException ex)
{
    System.Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    System.Console.WriteLine($"Erro: {ex.Message}");
}

//Operador ternario
int idade = 2;
string mensagem = idade >= 10 ? "Pode dirigir" : "Não pode dirigir";
System.Console.WriteLine(mensagem);
*/

