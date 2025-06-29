namespace _3_Sistema_Console.Models
{
    class Livro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}
